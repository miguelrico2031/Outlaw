using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 direction)
    {
        //rb.velocity=new Vector2(1,0) *speed;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Objects"))
        {
            Destroy(gameObject);

        }

    }
}