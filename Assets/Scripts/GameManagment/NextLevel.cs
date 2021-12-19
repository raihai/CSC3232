using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
 
    //button functions to change inbetween scenes  

    public GameObject enterNextLevel;

    public void EnterLevel()
    {
        SceneManager.LoadScene("Level2");
    }
    public void FinalLevel()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ReturnLevel()
    {
        enterNextLevel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("Overworld");
    }
    public void ReturnToLevel1()
    {  
        SceneManager.LoadScene("Level1");
    }


    public void CancelLevel()
    {
        Time.timeScale = 1f;
        enterNextLevel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void EnterOverworldLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void CancelOverWorldLevel()
    {
        Time.timeScale = 1f;
        enterNextLevel.SetActive(false);
    }

    public void DeathReturn()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Overworld");
    }
    public void GameOver()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("FinishGame");
    }
}
