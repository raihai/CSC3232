using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public float health = 80f;
   

    [SerializeField]
    private float forceMagnitude;


    public GameObject Gems;
    public Transform postionGem;



    // box with item


    private void Start()
    {
  
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Death();
        }
    }

    

    void Death()
    {
        Rigidbody rb = Instantiate(Gems, postionGem.position, Quaternion.identity).GetComponent<Rigidbody>();
        

        Destroy(gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbody = collision.collider.attachedRigidbody;

        if (rigidbody != null)
        {
            Vector3 forceDirection = collision.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("PlayerSpell"))
        {
            int randomAttackDamage = Random.Range(20, 50);
            TakeDamage(randomAttackDamage);
        }
    }
}
