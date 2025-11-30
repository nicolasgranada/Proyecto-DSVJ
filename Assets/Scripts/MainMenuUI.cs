using UnityEngine;
using UnityEngine.SceneManagement;   // importante para cargar escenas

public class MainMenuUI : MonoBehaviour
{
    public GameObject panelIntegrantes;  // Panel con los nombres
    public GameObject panelMenu;         // Panel con START / EXIT / niveles

    void Start()
    {
        // Al abrir la escena mostramos el menú
        ShowMenu();

        // Menú sin música
        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopMusic();
        }
    }

    public void ShowNames()
    {
        // Mostrar nombres y ocultar menú
        if (panelIntegrantes != null) panelIntegrantes.SetActive(true);
        if (panelMenu != null) panelMenu.SetActive(false);

        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopMusic();
        }
    }

    public void ShowMenu()
    {
        // Mostrar menú y ocultar nombres
        if (panelIntegrantes != null) panelIntegrantes.SetActive(false);
        if (panelMenu != null) panelMenu.SetActive(true);

        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopMusic();
        }
    }

    // --------- BOTONES DE DIFICULTAD ---------

    public void PlayEasy()
    {
        DifficultySelector.selectedSpeed = 5f;   // velocidad fácil
        SceneManager.LoadScene("SampleScene");   // nombre de la escena del juego
    }

    public void PlayMedium()
    {
        DifficultySelector.selectedSpeed = 8f;   // velocidad media
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayHard()
    {
        DifficultySelector.selectedSpeed = 12f;  // velocidad difícil
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
