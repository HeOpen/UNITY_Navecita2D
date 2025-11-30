using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

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
    public GameObject pausePanel; 
    public bool isPaused = false;

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
        finalScoreText.text = score.ToString();
    }

    public void decreaseLife()
    {
        lives -= 1;
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        
		if(lives<=0)
		{
            // 1. Get the Name we saved in the input screen
            string playerName = PlayerPrefs.GetString("nombreUsuario", "Pilot");

            // 2. Save to the Top 10 List
            LeaderboardManager.SaveScore(playerName, score);

            // 3. Trigger Game Over
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

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        
        
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

}