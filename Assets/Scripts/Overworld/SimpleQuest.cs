using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SimpleQuest : MonoBehaviour
{
    

    [SerializeField]
    GameObject mainMenuUI;

    [SerializeField]
    GameObject Door;


    public static int playerHealth = 100;
    public TextMeshProUGUI playerHealthText;
    public static bool isGameOver;
    public GameObject damageOverlay;

    private PlayerStateMachine healthPower;
    public GameObject test;
    int increaseHealth = 15;


    enum GameMode
    {
        InGame,
        MainMenu,
    }


    GameMode gameMode = GameMode.MainMenu;



    // Start is called before the first frame update
    void Start()
    {

        string nname = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f;

        if (nname == "Overworld")
        {

            StartMainMenu();

        }else if(nname == "Level1" )
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }

        playerHealth = 100;

    }





    // Update is called once per frame
    void Update()
    {
        switch (gameMode)
        {
            case GameMode.MainMenu: UpdateMainMenu(); break;
           
            case GameMode.InGame: UpdateMainGame(); break;
  
        }

        playerHealthText.text =  "Health : " + playerHealth;
        if (isGameOver)
        {
            //Cursor.lockState = CursorLockMode.Confined;
           // Cursor.visible = true;
            SceneManager.LoadScene("MainMenu");
            isGameOver = false;
            

        }

        if (playerHealth < 30)
        {
            damageOverlay.SetActive(true);
        }

        /*healthPower = test.GetComponent<PlayerStateMachine>();

        if (healthPower.HealthUp == true)
        {
            playerHealth = playerHealth + increaseHealth;
        }*/

    }


    public  static void takeDamge(int damageAmount)
    {
        
        playerHealth -= damageAmount;
        if (playerHealth <= 0)
        {
            isGameOver = true;
        }
   
    }

    void UpdateMainMenu()
    {
       
    }

  

    void UpdateMainGame()
    {
        // playerObjectwwwww
    }



    void StartMainMenu()
    {
        gameMode = GameMode.MainMenu;
        Time.timeScale = 0f;

        mainMenuUI.gameObject.SetActive(true);
        
  
    }




    public void StartGame()
    {

        gameMode = GameMode.InGame;
        Time.timeScale = 1f;
        mainMenuUI.gameObject.SetActive(false);
       
        
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


}