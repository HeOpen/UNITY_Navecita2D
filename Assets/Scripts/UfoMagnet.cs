using UnityEngine;

public class UfoMagnet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 playerDireccion;
    private float timestamp;
    private GameObject player;
    // Removed the 'ufoMagnet' variable, as we check the status live

    private bool flyToPlayer = false; // Initialized to false

    void Start()
    {
        // Get this UFO's own Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        
        // Safety Check: UFOs require a Rigidbody2D for velocity commands
        if (rb == null)
        {
            Debug.LogError("UFO Magnet Script requires a Rigidbody2D component on the GameObject.");
            Destroy(this); // Stop the script from running
        }
    }

    void Update()
    {
        // If we are supposed to fly to the player, do it
        if (flyToPlayer && player != null) 
        {
            // Calculate direction from UFO to Player
            playerDireccion = -(transform.position - player.transform.position);

            // Apply velocity to move towards the player
            rb.linearVelocity = (Time.time / timestamp) * 5f * new Vector2(playerDireccion.x, playerDireccion.y);
        }
    }private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if we entered the correct "Magnet" trigger
        if (collision.tag == "Magnet") 
        {
            Debug.Log("UFO detected magnet trigger.");

            // Check 1: Does the Instance exist?
            if (LogicScript.Instancia == null)
            {
                Debug.LogError("Error: LogicScript Instance is NULL.");
                return; 
            }

            // Check 2: Is the magnet turned ON?
            if (LogicScript.Instancia.magnet)
            {
                Debug.Log("Magnet is ON. Activating attraction!");
            
                // ... (Your attraction code goes here) ...
            
                player = GameObject.FindGameObjectWithTag("Player"); 
                timestamp = Time.time; 
                flyToPlayer = true; 
            } 
            else
            {
                Debug.Log("Magnet is OFF. UFO ignored attraction.");
            }
        }
    }
}