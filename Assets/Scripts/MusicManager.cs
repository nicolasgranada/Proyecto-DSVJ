using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource musicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);   // Opcional: la música sobrevive entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 🔊 Encender música (cuando empieza el juego)
    public void PlayMusic()
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    // 🔇 Apagar música del todo (menú, game over, etc.)
    public void StopMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    // ⏸ Pausar música (pausa del juego, help, etc.)
    public void PauseMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Pause();
        }
    }

    // ▶️ Reanudar música desde donde quedó pausada
    public void ResumeMusic()
    {
        if (musicSource != null)
        {
            musicSource.UnPause();
        }
    }
}
