using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float lifetime = 7f; // tiempo máximo que puede existir antes de autodestruirse

    void Start()
    {
        // Destruir automáticamente después de X segundos
        Destroy(gameObject, lifetime);
    }

    // Este método se llama automáticamente cuando el collider del asteroide toca otro collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Aquí puedes filtrar con etiquetas si quieres, por ejemplo solo destruir con "Player" o "Bullet"
        // if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        // {
        //     Destroy(gameObject);
        // }

        // Por ahora destruimos con cualquier colisión
        Destroy(gameObject);
    }
}