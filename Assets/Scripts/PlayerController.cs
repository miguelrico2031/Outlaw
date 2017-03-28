﻿using System.Collections;
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

    void Awake()
    {
        //Obtenemos el componente de rigidbody
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
        //Obtenemos los valores de los ejes
	    float horizontal = Input.GetAxis("Horizontal"+playerId);
	    float vertical = Input.GetAxis("Vertical"+playerId);
        //Creamos un movimiento basado en los ejes y la velocidad
        Vector2 movement=new Vector2(horizontal,vertical)*speed;
        //Asignamos la velocidad al rigidbody
        rb.velocity = movement;

        anim.SetFloat("Speed",movement.magnitude);

        //COMPROBAMOS EL DISPARO
        if (Input.GetButtonDown("Fire" + playerId))
        {
            Vector2 direction = new Vector2(1, vertical);
            direction.Normalize();
            Bullet b = Instantiate(bullet, spawnPosition.position, Quaternion.identity).GetComponent<Bullet>();
            b.Init(new Vector2(direction.x * transform.localScale.x, direction.y));
        }
    }

    //private void OnCollisionEnter2D(Collision2D collisionInfo)
    //{
    //    print(collisionInfo.gameObject.name);
    //}

}
