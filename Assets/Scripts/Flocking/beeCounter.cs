using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class beeCounter : MonoBehaviour
{
    // counts bee defeated and actives the gate when the player has reached the required amount

    public Text progressUI;
    public GameObject taskComplete;
    public GameObject counter;

    public GameObject gate;
    public static int start = 0;
    

    void Start()
    {
        progressUI.text = " 0 / 20 BEE "; 
    }

    private void Update()
    {
        progressUI.text = start + " / 20 BEE";

       if (start >= 20)
        {
            taskComplete.SetActive(true);
            counter.SetActive(false);
            gate.SetActive(true);
           
           
        }
       



    }

}
