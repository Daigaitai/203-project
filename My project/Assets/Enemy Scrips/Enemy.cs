using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    public static bool isAttacking = false;
    
   
    


    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    //Attack
    void Update()
    {
       

        
    }
    //hurt
    public void TakeDamage(int damge)
    {
        if (currentHealth < 0) { return; };
        currentHealth -= damge;

        animator.SetTrigger("Hurt");

        GetComponent<AudioSource>().Play();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //Death
    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDeath",true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }

   
}
