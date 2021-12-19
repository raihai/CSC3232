using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class OverworldPlayer : MonoBehaviour
{

    // reference 

    PlayerControl playerControl;
    CharacterController overWorldPlayer;

   

    // store player input values
    Vector2 currentMoveInput;
    Vector3 appliedMovement;
    bool isMovePressed;


    public GameObject enterDoorWindow;




    public void Awake()
    {
        // instantiate 
        playerControl = new PlayerControl();
        overWorldPlayer = GetComponent<CharacterController>();

        // get user input
        playerControl.OverworldControls.Moves.started += OnMoveInput;
        playerControl.OverworldControls.Moves.canceled += OnMoveInput;
        playerControl.OverworldControls.Moves.performed += OnMoveInput;
    }
    // Start is called before the first frame update
    public void Start()
    {
        
    }


    void Update()
    {
        overWorldPlayer.Move(appliedMovement * Time.deltaTime);
    }

    // calculate movement 
    void OnMoveInput(InputAction.CallbackContext context)
    {
        currentMoveInput = context.ReadValue<Vector2>();
        appliedMovement.x = currentMoveInput.x * 3.0f;
        appliedMovement.z = currentMoveInput.y * 3.0f;
        isMovePressed = currentMoveInput.x != 0 || currentMoveInput.y != 0;
    }


    // trigger for door 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DoorOne")){

            
            enterDoorWindow.SetActive(true);
            Time.timeScale = 0f;

        } else if (other.gameObject.CompareTag("DoorTwo")){



        } else if (other.gameObject.CompareTag("DoorThree"))
        {

        }
        else
        {
            enterDoorWindow.SetActive(false);
        }
    }

    // enable action map
    private void OnEnable()
    {
        playerControl.OverworldControls.Enable();
    }

    //disable character control action map 
    private void OnDisable()
    {
        playerControl.OverworldControls.Disable();
    }
}
