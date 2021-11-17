using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell: MonoBehaviour
{

  
    //Destory Spell upon collision
  
    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);
    }
}


