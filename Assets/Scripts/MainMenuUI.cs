using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject panelIntegrantes;  // Panel con los nombres
    public GameObject panelMenu;         // Panel con START / EXIT

    void Start()
    {
        // Al iniciar el juego mostramos el MENÚ
        ShowMenu();
    }

    public void ShowNames()
    {
        // Muestra los nombres y oculta el menú
        if (panelIntegrantes != null) panelIntegrantes.SetActive(true);
        if (panelMenu != null) panelMenu.SetActive(false);
    }

    public void ShowMenu()
    {
        // Muestra el menú y oculta los nombres
        if (panelIntegrantes != null) panelIntegrantes.SetActive(false);
        if (panelMenu != null) panelMenu.SetActive(true);
    }
}
