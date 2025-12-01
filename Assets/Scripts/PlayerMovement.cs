using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5f;              // velocidad actual
    public Rigidbody rb;
    public float horizontalInput;
    public float horizontalMultiplier = 2f;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 600f;
    [SerializeField] LayerMask groundMask;

    void Start()
    {
        // 👉 aquí tomamos la velocidad según el nivel escogido en el menú
        speed = DifficultySelector.selectedSpeed;
        // el incremento por punto lo dejamos fijo, como ya lo tenías
        // (si luego quieres que cambie por dificultad, lo ajustamos)

        // 👉 Aplicar el color de la bola seleccionada
        ApplyBallColor();
    }

    void ApplyBallColor()
    {
        // Obtener el MeshRenderer del jugador
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        
        if (renderer != null)
        {
            // Aplicar el color seleccionado al material
            Material playerMaterial = renderer.material;
            playerMaterial.color = BallSelector.selectedBallColor;
        }
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
        {
            Jump();
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }
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
