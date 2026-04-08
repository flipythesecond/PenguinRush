using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator walkAnimation;

    public int health;
    public float jumpHeight;

    private bool jumpBuffer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        walkAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity += new Vector2(Time.deltaTime, 0.0f);
        walkAnimation.speed = rb.linearVelocityX;
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            jumpBuffer = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            Destroy(collision.gameObject);
            rb.linearVelocityX /= 2;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (jumpBuffer)
        {
            rb.linearVelocityY = jumpHeight;
            jumpBuffer = false;
        }
    }
}
