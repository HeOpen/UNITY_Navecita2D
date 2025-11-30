using UnityEngine;

public class ControladorNave : MonoBehaviour
{
    public float velocidad = 10f;
    public Rigidbody2D playerRb;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private float direcX;
    private float direcY;
    private Vector2 direc;

    private float deltaX;
    private float deltaY;
    private Vector2 touchPosition;

    void Start()
    {
        if (playerRb == null)
        {
            playerRb = GetComponent<Rigidbody2D>();
        }

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        direcX = Input.GetAxisRaw("Horizontal");
        direcY = Input.GetAxisRaw("Vertical");
        direc = new Vector2(direcX, direcY).normalized;
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0.5f; 
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 2.0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (LogicScript.Instancia != null)
            {
                LogicScript.Instancia.ActivaMagnet(); 
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPosition.x - transform.position.x;
                    deltaY = touchPosition.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    playerRb.MovePosition(new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY));
                    break;

                case TouchPhase.Ended:
                    playerRb.linearVelocity = Vector2.zero;
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.touchCount == 0)
        {
            playerRb.linearVelocity = new Vector2(direc.x * velocidad, direc.y * velocidad);
        }

        Vector3 viewPos = playerRb.position;
        
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        playerRb.position = viewPos;
    } 
}