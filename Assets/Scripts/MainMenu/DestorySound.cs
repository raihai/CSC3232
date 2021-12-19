using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySound : MonoBehaviour
{
    // destory menu sound 

    public void Start()
    {
        Destroy(gameObject, 3f);
    }

}
