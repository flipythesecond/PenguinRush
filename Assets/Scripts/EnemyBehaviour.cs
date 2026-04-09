using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    public float jumpMinX;
    public float jumpMaxX;
    public float jumpMinY;
    public float jumpMaxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            GetComponent<Animator>().Play("EmptyState");
            rb.linearVelocity = new Vector2(Random.Range(jumpMinX, jumpMaxX), Random.Range(jumpMinY, jumpMaxY));
        }
    }
}
