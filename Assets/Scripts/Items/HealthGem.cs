using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGem : MonoBehaviour
{
    public int RotateSpeed;
    
    // spins the gem
    void Update()
    {
        transform.Rotate(0, RotateSpeed, 0, Space.World);
    }

    //destorys the gem, adds health to the player's health and plays sound
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SimpleQuest.playerHealth += 50;
        }
    }
}
