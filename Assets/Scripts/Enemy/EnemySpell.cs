using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{ 

    
    public float radius = 2;
    public int damageAmount = 20;

    public AudioSource enemySpell;

    // play spell sound and register damage 

    private void OnCollisionEnter(Collision collision)
    {
        enemySpell.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearObject in colliders)
        {
            if (nearObject.tag == "Player")
            {
                SimpleQuest.TakeDamge(damageAmount);
               
            }
        }
        Destroy(gameObject);
    }
}
