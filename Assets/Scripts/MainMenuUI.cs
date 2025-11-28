using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject panelIntegrantes;
    public GameObject panelMenu;

    void Start()
    {
        // Al entrar en Play:
        if (panelIntegrantes != null)
            panelIntegrantes.SetActive(false);   // Oculta nombres

        if (panelMenu != null)
            panelMenu.SetActive(true);           // Muestra START / EXIT
    }
}
