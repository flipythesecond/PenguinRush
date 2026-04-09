using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator walkAnimation;

    public int health;
    public float jumpHeight;

    private bool jumpBuffer;

    public AudioClip damageSound;
    public AudioClip healthSound;
    private AudioSource audioSource;

    public float cameraOffsetX;
    public float cameraOffsetY;
    private Vector2 cameraVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        walkAnimation = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jumpBuffer = true;
        }
        
    }
    void FixedUpdate()
    {
        Vector2 newCameraPos = Vector2.SmoothDamp(Camera.main.transform.position, transform.position, ref cameraVelocity, Time.deltaTime);
        Camera.main.transform.SetPositionAndRotation(new Vector3(newCameraPos.x + cameraOffsetX, newCameraPos.y + cameraOffsetY, -10), Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            audioSource.PlayOneShot(damageSound);
            Destroy(collision.gameObject);
            if (health == 0)
            {
                walkAnimation.speed = 0;
                Destroy(this);
            }
        }

        if (collision.gameObject.CompareTag("Fish"))
        {
            health++;
            audioSource.PlayOneShot(healthSound);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (jumpBuffer)
        {
            rb.linearVelocityY = jumpHeight;
            jumpBuffer = false;
        }

        if (collision.gameObject.CompareTag("Terrain"))
        {
            rb.linearVelocity += new Vector2(Time.fixedDeltaTime, 0.0f);
            walkAnimation.speed = rb.linearVelocityX;
            Camera.main.GetComponent<VideoPlayer>().playbackSpeed = rb.linearVelocityX;
        }
    }
}
