using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5f;
    public Rigidbody rb;
    public float horizontalInput;
    public float horizontalMultiplier = 2f;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 600f;
    [SerializeField] LayerMask groundMask;

    public GameManager gameManager;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5f)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;

        if (gameManager != null)
        {
            gameManager.EndGame();
        }
    }

    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;

        bool isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            (height / 2) + 0.1f,
            groundMask
        );

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
