using UnityEngine;

public class MOB : MonoBehaviour
{
    public float speed = 5f;
    public int dano = 20;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public int health_mob = 10;

    public void TakeDamage_mob(int damageAmount)
    {
        health_mob -= damageAmount;

        if (health_mob <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        float move = speed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(0, 0, move);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Muda a direção do MOB para oposta quando colide com uma parede
            speed *= -1;
        }

        Player_movement player = collision.gameObject.GetComponent<Player_movement>();

        if (player != null)
        {
            player.TakeDamage_player(dano);
        }
    }
    }
