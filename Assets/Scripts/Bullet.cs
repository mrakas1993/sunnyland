using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private Rigidbody2D rb;
    public int damage = 3; // урон по врагу

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        if (player.transform.localScale.x > 0)
        {
            rb.linearVelocity = transform.right * speed;
        }
        else
        {
            rb.linearVelocity = -transform.right * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
