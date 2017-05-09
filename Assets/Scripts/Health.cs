using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Animator anim;
    public int lives = 3;
    public Image[] hearts;
    public Sprite heartLost;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            lives--;
            anim.SetTrigger("GetDamage");
            hearts[lives].sprite = heartLost;
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
