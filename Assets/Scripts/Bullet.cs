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

    public void DestroyBullet()
    {
        if (OnBulletDestroyed != null)
            OnBulletDestroyed();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DestroyBullet();
        }
        else if (other.gameObject.CompareTag("Objects"))
        {
            DestroyBullet();
        }
    }

}