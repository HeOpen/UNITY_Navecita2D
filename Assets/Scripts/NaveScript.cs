using UnityEngine;
public class ControladorNave : MonoBehaviour
{
public float velocidad = 1f;
public Rigidbody2D playerRb;
public float direcX, direcY;
public Vector2 direc;
public float limiteX = 8.67f;
public float limiteY = 4.81f;

// Start is called once before the first execution of Update after
//the MonoBehaviour is created
void Start()
{
     
}
// Update is called once per frame
void FixedUpdate()
{

     if (direcX>=limiteX){
          playerRb.linearVelocity = new Vector2(0,direc.y * velocidad); 
     }

     playerRb.position = new Vector2(Mathf.Clamp(playerRb.position.x, -limiteX,
     limiteX), Mathf.Clamp(playerRb.position.y, -limiteY, limiteY));
     

direcX = Input.GetAxisRaw("Horizontal");
direcY = Input.GetAxisRaw("Vertical");
direc = new Vector2(direcX, direcY).normalized;
playerRb.linearVelocity = new Vector2(direc.x * velocidad,
direc.y * velocidad);
}

}