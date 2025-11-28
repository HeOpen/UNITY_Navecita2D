using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class LogicScript : MonoBehaviour
{
    public static LogicScript Instancia; 
    
    public bool magnet = false; 

    public int score = 0;
    public int lives = 3;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text livesText;
    
    public Slider healthSlider;
	public GameObject GameOverScreen;

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
        
        if (livesText != null) 
        {
            livesText.text = lives.ToString(); 
        }

        if (healthSlider != null)
        {
            healthSlider.maxValue = lives;
            healthSlider.value = lives;
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        finalScoreText = scoreText.text;
    }

    public void decreaseLife()
    {
        lives -= 1;
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        
		if(lives<=0)
		{
			GameOver();
		}


        if (healthSlider != null)
        {
             healthSlider.value = lives;
        }

    }

	public void GameOver()
	{
		GameOverScreen.SetActive(true);
		Time.timeScale = 0f;
	}

    public void ActivaMagnet()
    {
        magnet = true; 
    }
}