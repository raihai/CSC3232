using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
 
    public GameObject enterNextLevel
        ;

    public void EnterLevel()
    {
        SceneManager.LoadScene("Level2");

    }

    public void ReturnLevel()
    {
        SceneManager.LoadScene("Level1");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enterNextLevel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CancelLevel()
    {
        Time.timeScale = 1f;
        enterNextLevel.SetActive(false);
    }


}
