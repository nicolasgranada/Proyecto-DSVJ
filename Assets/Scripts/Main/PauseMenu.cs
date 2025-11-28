using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PausePanel;

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;

        // 🔇 PAUSAR MÚSICA
        MusicManager.instance.PauseMusic();
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        // 🎵 REANUDAR MÚSICA
        MusicManager.instance.ResumeMusic();
    }

    public void Quit()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        // 🎵 REANUDAR MÚSICA (si vuelves al menú)
        MusicManager.instance.ResumeMusic();

        SceneManager.LoadSceneAsync(0);
    }

    public void Restart()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        // 🎵 REANUDAR MÚSICA EN EL REINICIO
        MusicManager.instance.ResumeMusic();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start() { }

    void Update() { }
}
