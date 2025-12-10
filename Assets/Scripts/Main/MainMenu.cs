using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayEasy()
    {
        DifficultySelector.selectedSpeed = 5f;
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void PlayMedium()
    {
        DifficultySelector.selectedSpeed = 7f;
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void PlayHard()
    {
        DifficultySelector.selectedSpeed = 10f;
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void PlayExtreme()
    {
        DifficultySelector.selectedSpeed = 16f;
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
