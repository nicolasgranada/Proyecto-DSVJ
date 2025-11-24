using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;
    public float horizontalInput;
    public float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 600f;
    [SerializeField] LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // movimiento a la esfera
    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }


    // Update is called once per frame
    void Update()
    {

        //llamar la funcion de salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        horizontalInput = Input.GetAxis("Horizontal");

        // para cuando se cae
        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        // Llama a EndGame del GameManager
        GameManager.inst.EndGame();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;

        // Verificar si está tocando el suelo
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        if (isGrounded)
        {
            // Si está tocando el suelo, permite el salto
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

}
