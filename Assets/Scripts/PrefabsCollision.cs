using UnityEngine;

public class PrefabsCollision : MonoBehaviour
{
    public LogicScript logic; 

    void Start()
    {
        // Busca el objeto que tiene el tag "Logic" (tu GameController)
        GameObject gameController = GameObject.FindGameObjectWithTag("Logic");
    
        if (gameController != null)
        {
            // Obtiene el componente LogicScript de ese objeto
            logic = gameController.GetComponent<LogicScript>();
        }
    
        // Verificación de seguridad
        if (logic == null)
        {
            Debug.LogError("¡Error! No se encontró el LogicScript. Asegúrate de que el GameController tiene el Tag 'Logic'.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Salir si la lógica del juego no está referenciada
        if (logic == null) return; 

        // Solo procesamos colisiones si el objeto golpeado es el Player
        if (collision.gameObject.CompareTag("Player"))
        {

            if (gameObject.CompareTag("UFO")) 
            {
                // Si este objeto es el UFO: sumar puntos
                logic.addScore();
                
                // Destruir el UFO
                Destroy(gameObject); 
            }
            else if (gameObject.CompareTag("Asteroid")) 
            {
                logic.decreaseLife(); 
               
                // Destruir el Asteroide (se puede cambiar por efectos más tarde)
                Destroy(gameObject); 
            }
        }
    }
}