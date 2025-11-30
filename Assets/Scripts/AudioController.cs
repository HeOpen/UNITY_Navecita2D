using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instancia;

    [Header("Audio Sources")]
    public AudioSource musicaFondo;
    public AudioSource efectoSonido; 

    [Header("Clips")]
    public AudioClip efectoBotonClick; 
    public AudioClip efectoExplosion;  

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("AudioController initialized and marked DontDestroyOnLoad");
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        if (musicaFondo != null && !musicaFondo.isPlaying)
        {
            musicaFondo.Play();
            musicaFondo.loop = true; 
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (musicaFondo != null)
        {
            musicaFondo.volume = volume;
        }
    }

}