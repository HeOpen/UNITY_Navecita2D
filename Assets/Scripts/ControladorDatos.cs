using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControladorDatos : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField nombreInput;
    public TMP_InputField edadInput;

    public void GuardarYJugar()
    {
        if (string.IsNullOrWhiteSpace(nombreInput.text))
        {
            Debug.Log("Error: Name cannot be empty!");
            return;
        }

        if (int.TryParse(edadInput.text, out int age))
        {
            if (age < 0)
            {
                Debug.Log("Error: Age cannot be negative!");
                return;
            }
        }
        
        PlayerPrefs.SetString("nombreUsuario", nombreInput.text);
        
        Debug.Log("Name: " + nombreInput.text + " | Age: " + edadInput.text);

        SceneManager.LoadScene("Game");
    }
}