using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float horizontal_input;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontal_input = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horizontal_input * speed,rb.linearVelocity.y);
    }
}
