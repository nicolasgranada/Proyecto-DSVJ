using UnityEngine;

public class LevelTheme : MonoBehaviour
{
    public Camera mainCamera;      // Cámara de la ESCENA DEL JUEGO
    public Color easyColor = Color.cyan;
    public Color mediumColor = Color.green;
    public Color hardColor = Color.red;

    void Start()
    {
        // Por si se te olvida arrastrar la cámara en el Inspector
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        float speed = DifficultySelector.selectedSpeed;

        // Elegimos color según la velocidad seleccionada en el menú
        if (speed <= 5.5f)
        {
            mainCamera.backgroundColor = easyColor;    // Easy
        }
        else if (speed <= 9f)
        {
            mainCamera.backgroundColor = mediumColor;  // Medium
        }
        else
        {
            mainCamera.backgroundColor = hardColor;    // Hard
        }
    }
}
