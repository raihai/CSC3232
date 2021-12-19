using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalTrigger : MonoBehaviour
{
    // Destroy crystal upon collision with player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            SimpleQuest.getCrystalCount++;
            Destroy(gameObject);

        }
    }
}
