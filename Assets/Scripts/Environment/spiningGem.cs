using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiningGem : MonoBehaviour
{
    public int RotateSpeed;

    
    //public GameObject actionText;
    //public bool magicPowerUp;
   // public int extra;

   // public Enemy attackPower;
   // public GameObject test;

    // Update is called once per frame


    void Update()
    {
        transform.Rotate(0, RotateSpeed, 0, Space.World);
     
    }

    private void OnTriggerEnter(Collider other)

    {
       // attackPower = test.GetComponent<Enemy>();

        if (other.gameObject.CompareTag("Player"))
        {
            Enemy.atackDamage = 40;
           
  
            Destroy(gameObject);
          
        }
        
    }
  



}
