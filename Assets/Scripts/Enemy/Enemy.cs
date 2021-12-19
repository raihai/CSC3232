using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // enemy variables 
    public int enemyHealth = 100;
    public GameObject enemySpell;
    public Transform enemySpellPoint;
    public Animator enemyAnimator;
    public GameObject test;
    public static int atackDamage = 25;
    public AudioSource playerSpell;
    public ParticleSystem bloodEffect;
    



    void Start()
    {
      
    }

    // enemy spell activation 
    public void shoot()
    {
        Rigidbody rb = Instantiate(enemySpell, enemySpellPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
        rb.AddForce(transform.up * 6.5f, ForceMode.Impulse);
    }



    private void Update()
    {
        Debug.Log(atackDamage);
    }

    // play animation when enemy is hit with player spell
    public virtual void TakeDamage(int randomAttackDamage)
    { 
        enemyHealth -= randomAttackDamage;
        Debug.Log(enemyHealth);
        if (enemyHealth <= 0) 
        {
            bloodEffect.Play();
            enemyAnimator.SetTrigger("Death");
            GetComponent<CapsuleCollider>().enabled = false;
         
                      
        }
        else
        {
            enemyAnimator.SetTrigger("Damage");
        }
    }


    // Calculating spell damage on enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerSpell"))
        {
            playerSpell.Play();
            TakeDamage(atackDamage);
        }   
    }




}
