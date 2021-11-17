using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterWorld : MonoBehaviour
{

    // 

    public GameObject enterDoorWindow;

    public void EnterLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void CancelLevel()
    {
        Time.timeScale = 1f;
        enterDoorWindow.SetActive(false);
    }

}
