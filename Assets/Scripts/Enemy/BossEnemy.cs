using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : Enemy
{
    public GameObject gameOver;

    // inherit from enemy, overrive TakeDamage function to add scene change after the boss's health reaches zero
    public override void TakeDamage(int randomAttackDamage)
    {

        enemyHealth -= randomAttackDamage;
        Debug.Log(enemyHealth);
        if (enemyHealth <= 0)

        {
            enemyAnimator.SetTrigger("Death");
            gameOver.SetActive(true);
           
            GetComponent<CapsuleCollider>().enabled = false;
            


        }
        else
        {
            enemyAnimator.SetTrigger("Damage");
        }
    }
}
