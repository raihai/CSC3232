using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // scene changer 
    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    // end game application 
    public void ExitScene()
    {
        Application.Quit();
    }

  

}
