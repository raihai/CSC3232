using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGem : MonoBehaviour
{
    public int RotateSpeed;


    public bool magicPowerUp;

   // public SimpleQuest health;
   // public GameObject test;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, RotateSpeed, 0, Space.World);

    }

    private void OnTriggerEnter(Collider other)

    {
        //health = test.GetComponent<SimpleQuest>();

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SimpleQuest.playerHealth = 150;


          

        }

    }
}
