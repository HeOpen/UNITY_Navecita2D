using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int score=0;
    public int lives = 3;
    //public Text scoreText;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void decreaseLife()
    {
        score -= 1; // Si quieres que restar vida también reste puntos
        lives -= 1;
    
        // El texto de puntuación se actualiza con la PUNTUACIÓN
        scoreText.text = score.ToString();
    
        // El texto de vidas se actualiza con la VIDA (CORRECCIÓN AQUÍ)
        livesText.text = lives.ToString();
    }
}
