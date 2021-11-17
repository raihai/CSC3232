using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CrystalCounter : MonoBehaviour
{
    // crystal counter

    public Text progressUI;
    public int crystals = 3;
    public static int start = 0;
    

    void Start()
    {
        progressUI.text = "0/3 Crystals ";
    }

    private void Update()
    {
        progressUI.text = +start + "/" + crystals + "Crystals";

    }

   
}
