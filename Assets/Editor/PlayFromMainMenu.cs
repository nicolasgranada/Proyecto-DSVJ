#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class PlayFromMainMenu
{
    // Se ejecuta automáticamente cuando se carga el editor
    static PlayFromMainMenu()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        // Justo antes de entrar en Play
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            // Ruta de tu escena de menú (ajusta el nombre si es distinto)
            string mainMenuPath = "Assets/Scenes/Main Menu.unity";

            // Si la escena activa NO es el menú, la abrimos antes de jugar
            if (EditorSceneManager.GetActiveScene().path != mainMenuPath)
            {
                EditorSceneManager.OpenScene(mainMenuPath);
            }
        }
    }
}
#endif
