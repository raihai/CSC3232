using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiningGem : MonoBehaviour
{
    public int RotateSpeed;

    // spins the gem
    void Update()
    {
        transform.Rotate(0, RotateSpeed, 0, Space.World);
    }

    //destorys the gem, increase damage strength and plays sounds
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SimpleQuest.playerPower += 20;
            Destroy(gameObject);
        }
        
    }
    
    



}
