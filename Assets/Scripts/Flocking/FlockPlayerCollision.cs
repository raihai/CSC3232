using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlockPlayerCollision : MonoBehaviour
{
    
    // disable bee and increase bee defeated counter

    private void OnCollisionEnter(Collision collision)
    {
    

        if (collision.gameObject.CompareTag("PlayerSpell"))
            { 
                gameObject.SetActive(false);
                beeCounter.start++;
                
            }
        
    }

}
