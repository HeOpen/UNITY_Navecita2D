using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void Lento()
    {
        Time.timeScale = 0.25f; // Juego más lento
    }

    public void Rapido()
    {
        Time.timeScale = 2f; // Juego más rápido
    }

    public void Normal()
    {
        Time.timeScale = 1f; // Velocidad normal
    }
}
