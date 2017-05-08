using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Animator anim;
    public int lives = 3;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            lives--;
            anim.SetTrigger("GetDamage");
            if (lives == 0)
            {
                anim.SetBool("Die",true);
            }
        }
        
    }
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
    }
	
	
}
