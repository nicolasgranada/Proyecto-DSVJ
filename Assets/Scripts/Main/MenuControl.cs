using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void ReturnGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
