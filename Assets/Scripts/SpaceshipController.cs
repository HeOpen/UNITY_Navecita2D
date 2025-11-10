using UnityEngine;

public class ControladorNave : MonoBehaviour
{
    public float velocidad = 10f;
    public Rigidbody2D playerRb;
    public float limiteX = 7.54f; 
    public float limiteY = 4.16f; 

    private float direcX;
    private float direcY;
    private Vector2 direc;

    void Start()
    {
        if (playerRb == null)
        {
            playerRb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        direcX = Input.GetAxisRaw("Horizontal");
        direcY = Input.GetAxisRaw("Vertical");
        direc = new Vector2(direcX, direcY).normalized;
    }

    void FixedUpdate()
    {
        playerRb.linearVelocity = new Vector2(direc.x * velocidad, direc.y * velocidad);
        playerRb.position = new Vector2(
            Mathf.Clamp(playerRb.position.x, -limiteX, limiteX),
            Mathf.Clamp(playerRb.position.y, -limiteY, limiteY)
        );
    } 
}