using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySound : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Destroy(gameObject, 3f);
    }

}
