using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuest : MonoBehaviour
{
    private int sideQuestComplete;
    public GameObject petBat;
    public GameObject crystalText;
    
    //active pet game object upon completion of side quest task

    void Start()
    {
       
    }

    
    void Update()
    {
        sideQuestComplete = SimpleQuest.getCrystalCount;

        if (sideQuestComplete >= 5)
        {
            petBat.SetActive(true);
            crystalText.SetActive(false);
        }
    }
}
