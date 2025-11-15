using UnityEngine;

public class MagnetController : MonoBehaviour
{
    public GameObject player;
    
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(
                player.transform.position.x,
                player.transform.position.y,
                player.transform.position.z
            );
        }
    }
}
