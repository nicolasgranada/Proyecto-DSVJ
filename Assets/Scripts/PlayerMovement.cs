using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed;                  // viene desde el menú
    public Rigidbody rb;
    public float horizontalInput;
    public float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 600f;
    [SerializeField] LayerMask groundMask;

    void Start()
    {
        // aplicar dificultad seleccionada
        speed = DifficultySelector.selectedSpeed;
        speedIncreasePerPoint = DifficultySelector.speedIncreasePerPoint;
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
            Die();
    }

    public void Die()
    {
        alive = false;
        GameManager.inst.EndGame();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        if (isGrounded)
            rb.AddForce(Vector3.up * jumpForce);
    }
}
