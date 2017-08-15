using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public Sprite[] cactusState;
    private int state = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            state++;
            GetComponent<SpriteRenderer>().sprite = cactusState[state];
        }
        if (state >= 3)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
