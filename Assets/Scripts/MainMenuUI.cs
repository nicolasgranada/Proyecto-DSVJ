using UnityEngine;
using UnityEngine.SceneManagement;   // importante para cargar escenas

public class MainMenuUI : MonoBehaviour
{
    public GameObject panelIntegrantes;  // Panel con los nombres
    public GameObject panelMenu;         // Panel con START / EXIT / niveles
    public GameObject panelSeleccionBola; // Panel con botones de selección de bola (opcional)

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
        // Mostrar menú y ocultar nombres y panel de selección de bola
        if (panelIntegrantes != null) panelIntegrantes.SetActive(false);
        if (panelMenu != null) panelMenu.SetActive(true);
        if (panelSeleccionBola != null) panelSeleccionBola.SetActive(false);

        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopMusic();
        }
    }

    public void ShowBallSelection()
    {
        Debug.Log("=== ShowBallSelection llamado ===");
        
        // Primero ocultar el menú principal
        if (panelMenu != null)
        {
            panelMenu.SetActive(false);
            Debug.Log("PanelMenu desactivado: " + panelMenu.activeSelf);
        }
        else
        {
            Debug.LogError("PanelMenu es NULL!");
        }
        
        if (panelIntegrantes != null) 
        {
            panelIntegrantes.SetActive(false);
            Debug.Log("PanelIntegrantes desactivado");
        }
        
        // Luego mostrar panel de selección de bola
        if (panelSeleccionBola != null)
        {
            panelSeleccionBola.SetActive(true);
            Debug.Log("Panel de selección de bola activado: " + panelSeleccionBola.activeSelf);
            
            // Verificar que los botones hijos estén activos
            int childCount = panelSeleccionBola.transform.childCount;
            Debug.Log("Número de hijos en PanelSeleccionBola: " + childCount);
            
            for (int i = 0; i < childCount; i++)
            {
                Transform child = panelSeleccionBola.transform.GetChild(i);
                Debug.Log($"Hijo {i}: {child.name} - Activo: {child.gameObject.activeSelf}");
            }
        }
        else
        {
            Debug.LogError("¡ERROR! PanelSeleccionBola no está conectado al script MainMenuUI. Por favor arrastra PanelSeleccionBola al campo 'Panel Seleccion Bola' en MainMenuUIManager.");
        }
    }

    public void HideBallSelection()
    {
        // Ocultar panel de selección de bola y mostrar menú principal
        if (panelSeleccionBola != null) panelSeleccionBola.SetActive(false);
        if (panelMenu != null) panelMenu.SetActive(true);
    }

    // --------- BOTONES DE DIFICULTAD ---------

    public void PlayEasy()
    {
        DifficultySelector.selectedSpeed = 5f;   // velocidad fácil
        ShowBallSelection(); // Mostrar menú de selección de bola
    }

    public void PlayMedium()
    {
        DifficultySelector.selectedSpeed = 8f;   // velocidad media
        ShowBallSelection(); // Mostrar menú de selección de bola
    }

    public void PlayHard()
    {
        DifficultySelector.selectedSpeed = 12f;  // velocidad difícil
        ShowBallSelection(); // Mostrar menú de selección de bola
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // --------- BOTONES DE SELECCIÓN DE BOLA ---------

    void StartGame()
    {
        // Cargar la escena del juego después de seleccionar el color
        SceneManager.LoadScene("SampleScene");
    }

    public void SelectBallRed()
    {
        BallSelector.selectedBallColor = new Color(0.9f, 0.1f, 0.1f, 1f);  // Rojo
        BallSelector.selectedBallName = "Red";
        StartGame(); // Iniciar el juego después de seleccionar
    }

    public void SelectBallBlue()
    {
        BallSelector.selectedBallColor = new Color(0.1f, 0.3f, 0.9f, 1f);  // Azul
        BallSelector.selectedBallName = "Blue";
        StartGame(); // Iniciar el juego después de seleccionar
    }

    public void SelectBallGreen()
    {
        BallSelector.selectedBallColor = new Color(0.1f, 0.8f, 0.2f, 1f);  // Verde
        BallSelector.selectedBallName = "Green";
        StartGame(); // Iniciar el juego después de seleccionar
    }

    public void SelectBallYellow()
    {
        BallSelector.selectedBallColor = new Color(1f, 0.9f, 0.1f, 1f);  // Amarillo
        BallSelector.selectedBallName = "Yellow";
        StartGame(); // Iniciar el juego después de seleccionar
    }

    public void SelectBallPurple()
    {
        BallSelector.selectedBallColor = new Color(0.7f, 0.2f, 0.9f, 1f);  // Morado
        BallSelector.selectedBallName = "Purple";
        StartGame(); // Iniciar el juego después de seleccionar
    }

    public void SelectBallOrange()
    {
        BallSelector.selectedBallColor = new Color(1f, 0.5f, 0.1f, 1f);  // Naranja
        BallSelector.selectedBallName = "Orange";
        StartGame(); // Iniciar el juego después de seleccionar
    }

    public void SelectBallDefault()
    {
        BallSelector.selectedBallColor = new Color(0.23773581f, 0f, 0f, 1f);  // Color por defecto (rojo oscuro)
        BallSelector.selectedBallName = "Default";
        StartGame(); // Iniciar el juego después de seleccionar
    }
}
