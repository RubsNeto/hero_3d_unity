using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 300f; // Força do pulo
    public float lookSpeed = 2f; // Velocidade de rotação da câmera
    public GameObject spherePrefab;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private Rigidbody playerRigidbody;

    public int health_player = 100;

    public void TakeDamage_player(int damageAmount)
    {

        health_player -= damageAmount;

        if (health_player <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Jump()
    {
        // Adiciona uma força vertical para simular o pulo
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Update()
    {
        // Obtemos o input do mouse para rotacionar a câmera
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY += Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f); // Limita a rotação em um ângulo máximo de 90 graus

        // Aplica a rotação da câmera
        transform.localRotation = Quaternion.Euler(-rotationY, rotationX, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject sphere = Instantiate(spherePrefab, transform.position, Quaternion.identity);
        }


    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
    }

    void Move(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + transform.TransformDirection(movement));
    }



}
