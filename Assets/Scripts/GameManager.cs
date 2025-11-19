using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    public Text scoreText;
    public PlayerMovement playerMovement;
    public GameObject endCanvas; 
    public Text endScoreText;    

    private void Awake()
    {
        inst = this;
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    public void EndGame()
    {
        playerMovement.enabled = false;
        endCanvas.SetActive(true);
        endScoreText.text = "PowerUps Recolectados: " + score;
    }

    void Start()
    {
        endCanvas.SetActive(false);
    }
}
