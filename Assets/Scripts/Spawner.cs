using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public float minX, maxX;
    public float minY, maxY;
    public float timeBetweenSpawn = 2f;
    public float launchForce = 250f;

    void Start()
    {
        // Llama a Spawn cada X segundos de forma automática
        InvokeRepeating(nameof(Spawn), 0f, timeBetweenSpawn);
    }

    void Spawn()
    {
        // 1. Posición aleatoria
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0);

        // 2. Rotación aleatoria para variar asteroides
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        // 3. Instanciar prefab
        GameObject newAsteroid = Instantiate(obstacle, spawnPosition, randomRotation);

        // 4. Lanzar hacia la izquierda
        Rigidbody2D rb = newAsteroid.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.left * launchForce);
        }
        else
        {
            Debug.LogWarning("El prefab no tiene Rigidbody2D asignado.");
        }
    }
}
