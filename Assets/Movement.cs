using UnityEngine;


public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Prędkość poruszania się
    public float jumpForce = 5f;  // Siła skoku

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Pobierz komponent Rigidbody przypisany do gracza
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Obsługa ruchu poziomego
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // Przekształć ruch względem kierunku kamery (opcjonalne)
        move = Camera.main.transform.TransformDirection(move);
        move.y = 0; // Ignoruj ruch na osi Y kamery

        rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);

        // Obsługa skoku
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Ustal, czy gracz dotyka podłoża
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}