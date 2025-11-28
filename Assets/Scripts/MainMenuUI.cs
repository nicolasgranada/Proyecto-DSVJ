using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject panelIntegrantes;  // Panel con los nombres
    public GameObject panelMenu;         // Panel con START / EXIT

    void Start()
    {
        // Al abrir la escena queremos ver el MENÚ
        ShowMenu();

        // Asegurarnos que no haya música en el menú
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

        // En la pantalla de nombres tampoco queremos música
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

        // Menú en silencio también
        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopMusic();
        }
    }
}
