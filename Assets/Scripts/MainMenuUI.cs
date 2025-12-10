using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuUI : MonoBehaviour
{
    [Header("PANELS")]
    public GameObject panelIntegrantes;
    public GameObject panelMenu;
    public GameObject panelSeleccionBola;
    public GameObject fondoMenu;

    void Start()
    {
        // Fondo negro
        if (fondoMenu != null)
        {
            var img = fondoMenu.GetComponent<Image>();
            if (img != null)
                img.color = Color.black;
        }

        // Aplicar estilos visuales
        StyleButtons(panelMenu, isBallSelection:false);
        StyleButtons(panelSeleccionBola, isBallSelection:true);

        ShowMenu();

        MusicManager.instance?.StopMusic();
    }

    // ====================================================================
    // ESTILO DE BOTONES
    // ====================================================================
    void StyleButtons(GameObject panel, bool isBallSelection)
    {
        if (panel == null) return;

        Button[] botones = panel.GetComponentsInChildren<Button>(true);

        foreach (var btn in botones)
        {
            var img = btn.GetComponent<Image>();
            var txt = btn.GetComponentInChildren<TMPro.TextMeshProUGUI>();

            // Colores base
            if (img != null)
            {
                img.color = isBallSelection ?
                    new Color(0.05f, 0.05f, 0.05f) :   // negro suave para selección bola
                    new Color(0.15f, 0.15f, 0.15f);    // gris oscuro para menú
            }

            // Texto blanco
            if (txt != null)
            {
                txt.color = Color.white;
                txt.fontSize = 45;
            }

            // Hover
            AddHover(btn.gameObject, img);
        }
    }

    // ====================================================================
    // HOVER
    // ====================================================================
    void AddHover(GameObject buttonObj, Image img)
    {
        var trigger = buttonObj.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = buttonObj.AddComponent<EventTrigger>();

        trigger.triggers.Clear();

        // HOVER ENTER
        EventTrigger.Entry enter = new EventTrigger.Entry();
        enter.eventID = EventTriggerType.PointerEnter;
        enter.callback.AddListener((eventData) =>
        {
            buttonObj.transform.localScale = Vector3.one * 1.1f;     // Zoom suave
            if (img != null) img.color *= 1.2f;                      // Un poquito más claro
        });
        trigger.triggers.Add(enter);

        // HOVER EXIT
        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener((eventData) =>
        {
            buttonObj.transform.localScale = Vector3.one;
            if (img != null) img.color *= 0.85f;                     // Regresa al tono original
        });
        trigger.triggers.Add(exit);
    }

    // ====================================================================
    // MENÚ PRINCIPAL
    // ====================================================================
    public void ShowMenu()
    {
        panelIntegrantes?.SetActive(false);
        panelMenu?.SetActive(true);
        panelSeleccionBola?.SetActive(false);

        MusicManager.instance?.StopMusic();
    }

    public void ShowNames()
    {
        panelIntegrantes?.SetActive(true);
        panelMenu?.SetActive(false);

        MusicManager.instance?.StopMusic();
    }

    // ====================================================================
    // SELECCIÓN DE BOLA
    // ====================================================================
    public void ShowBallSelection()
    {
        panelMenu?.SetActive(false);
        panelIntegrantes?.SetActive(false);
        panelSeleccionBola?.SetActive(true);
    }

    public void HideBallSelection()
    {
        panelSeleccionBola?.SetActive(false);
        panelMenu?.SetActive(true);
    }

    // ====================================================================
    // DIFICULTADES
    // ====================================================================
    public void PlayEasy()   { DifficultySelector.selectedSpeed = 5f; ShowBallSelection(); }
    public void PlayMedium() { DifficultySelector.selectedSpeed = 7f; ShowBallSelection(); }
    public void PlayHard()   { DifficultySelector.selectedSpeed = 10f; ShowBallSelection(); }
    public void PlayExtreme()   { DifficultySelector.selectedSpeed = 16f; ShowBallSelection(); }


    // ====================================================================
    // INICIAR JUEGO
    // ====================================================================
    void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SelectBallRed()    { BallSelector.selectedBallColor = new Color(0.9f, 0.1f, 0.1f); BallSelector.selectedBallName = "Red"; StartGame(); }
    public void SelectBallBlue()   { BallSelector.selectedBallColor = new Color(0.1f, 0.3f, 0.9f); BallSelector.selectedBallName = "Blue"; StartGame(); }
    public void SelectBallGreen()  { BallSelector.selectedBallColor = new Color(0.1f, 0.8f, 0.2f); BallSelector.selectedBallName = "Green"; StartGame(); }
    public void SelectBallYellow() { BallSelector.selectedBallColor = new Color(1f, 0.9f, 0.1f); BallSelector.selectedBallName = "Yellow"; StartGame(); }
    public void SelectBallPurple() { BallSelector.selectedBallColor = new Color(0.7f, 0.2f, 0.9f); BallSelector.selectedBallName = "Purple"; StartGame(); }
    public void SelectBallOrange() { BallSelector.selectedBallColor = new Color(1f, 0.5f, 0.1f); BallSelector.selectedBallName = "Orange"; StartGame(); }
    public void SelectBallDefault(){ BallSelector.selectedBallColor = new Color(0.23f, 0f, 0f); BallSelector.selectedBallName = "Default"; StartGame(); }

    public void QuitGame()
    {
        Application.Quit();
    }
}
