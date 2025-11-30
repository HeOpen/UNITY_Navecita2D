using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject optionsPanel;
    public GameObject instructionsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(1); 
    }
    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}