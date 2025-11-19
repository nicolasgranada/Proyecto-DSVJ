using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.Die();
        }
    }
}
