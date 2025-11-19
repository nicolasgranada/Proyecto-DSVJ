using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }

        GameManager.inst.IncrementScore();

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, turnSpeed * Time.deltaTime);
    }
}
