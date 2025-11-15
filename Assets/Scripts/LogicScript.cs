using UnityEngine;
using TMPro;
using UnityEngine.UI; // 👈 1. REQUIRED: Add the UI namespace

public class LogicScript : MonoBehaviour
{
    // === 1. ADD THIS INSTANCE (SINGLETON) ===
    public static LogicScript Instancia; 
    
    // === 2. ADD THIS BOOLEAN ===
    public bool magnet = false; 

    // --- Your Existing Code ---
    public int score = 0;
    public int lives = 3;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    
    // 👈 2. FIX: Change 'HealthBar' to the built-in 'Slider'
    public Slider healthSlider; // Renamed for clarity 
    // --- End of Your Code ---

    // === 3. ADD THIS Awake() METHOD ===
    private void Awake() 
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        
        // Ensure UI elements are connected before using them
        if (livesText != null) 
        {
            // 👈 3. FIX: livesText is TMP, requires .text assignment
            livesText.text = lives.ToString(); 
        }

        if (healthSlider != null)
        {
            // 👈 4. ADAPT: Set Max Value and current Value on the Slider component
            healthSlider.maxValue = lives; // Sets the bar's full size
            healthSlider.value = lives;    // Sets the bar's current fill level
        }
    }

    // --- Your Existing Methods ---
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void decreaseLife()
    {
        lives -= 1;
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        
        if (healthSlider != null)
        {
             // 👈 5. ADAPT: Update the Slider's value (current health)
             healthSlider.value = lives;
        }

        // Add Game Over logic here later (1.17)
    }

    public void ActivaMagnet()
    {
        magnet = true; 
    }
}