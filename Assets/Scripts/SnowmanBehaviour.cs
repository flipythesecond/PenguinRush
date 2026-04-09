using UnityEngine;

public class SnowmanBehaviour : MonoBehaviour
{

    public GameObject snowball;
    public float throwTimeMin;
    public float throwTimeMax;
    public float snowballThrowSpeed;
    private float throwTime;
    private float lastThrowTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        throwTime = Random.Range(throwTimeMin, throwTimeMax);
        lastThrowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastThrowTime > throwTime)
        {
            GameObject thrown = Instantiate(snowball, transform.localPosition, Quaternion.identity);
            thrown.GetComponent<Rigidbody2D>().linearVelocityX = snowballThrowSpeed;
            lastThrowTime = Time.time;
        }
    }
}
