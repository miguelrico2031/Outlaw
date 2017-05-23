using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public int playerId = 1;
    //CREAMOS UNA VELOCIDAD Y UN RIGIDBODY
    public float speed = 30;
    public GameObject bullet;
    public Transform spawnPosition;
    private Rigidbody2D rb;
    private Animator anim;
    private bool bulletCreated;
    private Bullet CurrentBullet;
    private Health health;
    private bool alive = true;
    void Awake()
    {
        //Obtenemos el componente de rigidbody
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        health.OnPlayerDeath += OnPlayerDeath;
    }

    void Update ()
    {
        if (alive)
        {
            if (!bulletCreated)
            {
                //Obtenemos los valores de los ejes
                float horizontal = Input.GetAxis("Horizontal" + playerId);
                float vertical = Input.GetAxis("Vertical" + playerId);
                //Creamos un movimiento basado en los ejes y la velocidad
                Vector2 movement = new Vector2(horizontal, vertical)*speed;
                //Asignamos la velocidad al rigidbody
                rb.velocity = movement;

                anim.SetFloat("Speed", movement.magnitude);

                //Instanciamos la bala
                if (Input.GetButtonDown("Fire" + playerId))
                {

                    Vector2 direction = new Vector2(1, vertical);
                    direction.Normalize();
                    anim.SetBool("Shooting", true);
                    anim.SetFloat("ShootingDirection", direction.y);
                    CurrentBullet =
                        Instantiate(bullet, spawnPosition.position, Quaternion.identity).GetComponent<Bullet>();
                    CurrentBullet.Init(new Vector2(direction.x*transform.localScale.x, direction.y));
                    CurrentBullet.OnBulletDestroyed += OnBulletDestroyed;
                    bulletCreated = true;
                    rb.velocity = Vector2.zero;
                    anim.SetFloat("Speed", 0);
                }
            }
        }
    }

    private void OnBulletDestroyed()
    {
        anim.SetBool("Shooting", false);
        print("Se destruyó la bala.");
        CurrentBullet.OnBulletDestroyed -= OnBulletDestroyed;
        bulletCreated = false;
    }

    private void OnPlayerDeath()
    {
        alive = false;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sortingOrder = -1;
    }

    //private void OnCollisionEnter2D(Collision2D collisionInfo)
    //{
    //    print(collisionInfo.gameObject.name);
    //}

}

