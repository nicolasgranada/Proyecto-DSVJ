using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;

        // Pausar música mientras el juego está en pausa
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PauseMusic();
        }
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;

        // Reanudar música al continuar
        if (MusicManager.instance != null)
        {
            MusicManager.instance.ResumeMusic();
        }
    }

    public void Quit()
    {
        // Volver al menú principal (escena 0)
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);

        // Apagar música al salir de la partida
        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopMusic();
        }
    }

    public void Restart()
    {
        // Reiniciar escena actual
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);

        // Volver a encender música al reiniciar
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PlayMusic();
        }
    }
}
