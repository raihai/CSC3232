using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SimpleQuest : MonoBehaviour
{
   
    [SerializeField]
    GameObject mainMenuUI;

    // player health variables  

    public static int playerHealth = 100;
    public TextMeshProUGUI playerHealthText;
    private string healthCount;

    // damage and death variables
    public static bool isGameOver;
    public GameObject damageOverlay;

    // player power variable
    public TextMeshProUGUI playerPowerText;
    public static int playerPower = 25;
    private string powerCount;
    public GameObject player;
 

    public AudioSource backgroundMusic;
    public GameObject playerDeath;

    // crystal count variables 
    public static int getCrystalCount = 0;
    public Text progressUI;
    private string crystalCount;
    


    // Game manager 

    void Start()
    {
        // check level to ensure the scene starts correctly 

        string nname = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f;
        progressUI.text = "0 / 5 Crystal Collected";

        if (nname == "Overworld")
        {

            StartMainMenu();


        }else if(nname == "Level1" )
          
        {

            backgroundMusic.Play();
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            playerHealth = 100;
            playerPower = 25;
            getCrystalCount = 0;
            PlayerPrefs.SetInt(crystalCount, 0);
            PlayerPrefs.SetInt(healthCount, 100);
            PlayerPrefs.SetInt(powerCount, 25);
        } else
        {

            
            StartMainMenu();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            PlayerPrefs.GetInt(crystalCount);
            PlayerPrefs.GetInt(healthCount);
            Enemy.atackDamage += PlayerPrefs.GetInt(powerCount);

        }

        progressUI.text = crystalCount + " / 5 Crystals Collected";

        playerHealthText.text = "Health : " + healthCount;

        playerPowerText.text = "Power : " + powerCount;

    }



    void Update()
    {

        // check and display player health

        playerHealthText.text =  "Health : " + playerHealth;
        if (isGameOver)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerPrefs.SetInt(crystalCount, 0);
            PlayerPrefs.SetInt(healthCount, 100);
            PlayerPrefs.SetInt(powerCount, 25);
            playerDeath.SetActive(true);
            isGameOver = false;
            

        }

        if (playerHealth < 30)
        {
            damageOverlay.SetActive(true);
        }

        // save health for next level

        PlayerPrefs.SetInt(healthCount, playerHealth);


        // save crystal count for next level
        PlayerPrefs.SetInt(crystalCount, getCrystalCount);

        progressUI.text = getCrystalCount + " / 5 Crystals Collected";

        // power strength save for next level

        PlayerPrefs.SetInt(powerCount, playerPower);

        playerPowerText.text = "Power : " + playerPower;

        Enemy.atackDamage = PlayerPrefs.GetInt(powerCount);


    }

    // Damage to player 

    public  static void TakeDamge(int damageAmount)
    {
        
        playerHealth -= damageAmount;
        if (playerHealth <= 0)
        {
            isGameOver = true;
        }

    }

  

    // pause game and active menu UI

    void StartMainMenu()
    {
      
        Time.timeScale = 0f;

        mainMenuUI.gameObject.SetActive(true);
        
  
    }


    // resume gameplay

    public void StartGame()
    {

        Time.timeScale = 1f;
        mainMenuUI.gameObject.SetActive(false);
       
        
    }

    // resume level2 

    public void StartLevel2()
    {
        backgroundMusic.Play();
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        mainMenuUI.gameObject.SetActive(false);
    }

    // resume level3

    public void StartLevel3()
    {
        backgroundMusic.Play();
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        mainMenuUI.gameObject.SetActive(false);


    }

    // stop application 
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


}