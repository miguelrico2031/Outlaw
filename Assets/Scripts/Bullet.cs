using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public event Action OnBulletDestroyed;

    private Rigidbody2D rb;
    public float speed = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(OnBulletDestroyed!=null)
                OnBulletDestroyed();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Objects"))
        {
            if (OnBulletDestroyed != null)
                OnBulletDestroyed();
            Destroy(gameObject);
        }
    }
}