using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerStateMachine : MonoBehaviour
{

    // reference variables
    PlayerControl playerControl;
    CharacterController characterController;
    Animator animator;

    // camera
    [SerializeField]
    private Transform cameraTransform;

    // animator parameter hashes for better efficiency
    int walkingHash;
    int runningHash;
    int jumpingHash;


    // store player input values
    Vector2 currentMoveInput;
    Vector3 currentMove;
    Vector3 appliedMovement;

    
    bool isMovePressed;
    bool isRunPressed;


    //constants
    float rotationFactorEachFrame = 3.0f;
    float runSpeedMultiply = 5.0f;
    int zero = 0;
    


    // variables for gravity
    float gravity = -9.8f;
    float groundGravity = -.05f;


    // variables for jump
    bool isJumping = false;
    float jumpVelocity;
    float maxJumpHeight = 5f;
    float maxJumpTime = 1f;
    bool jumping = false;
   



    // variables for attack
    bool isAttackingPressed;
    int attackingHash;
    public AudioSource attackSound;
    public GameObject spell;
    public Transform spellPoint;

        //state variables
    PlayerBaseState currentState;
    PlayerStateFactory states;

    //Collect variables
    bool isCollecting = false;
    public float theDistance;
   /* public GameObject actionDisplay;
    public GameObject actionText;*/
    public GameObject MagicGem;
    public GameObject HealthGem;
    public AudioSource collectSound;

    // PowerUp variables 

    /*public bool magicPowerUp;
    public bool HealthUp;*/


    // getter and setter
    public CharacterController CharacterController { get { return characterController; } }
    public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public Animator Animator { get { return animator; } }

   // public AudioSource AttackSound { get { return attackSound;} }

    public int JumpHash { get { return jumpingHash; } }
    public int WalkingHash { get{ return walkingHash; } }
    public int RunningHash { get { return runningHash; } }
    public int AttackingHash { get { return attackingHash; } }
   


    public bool Jumping { set { jumping = value; } }
    public bool IsJumping { get { return isJumping; } }
    public bool MovePressed { get { return isMovePressed; } }
    public bool RunPressed { get { return isRunPressed; } }
    public bool IsAttackingPressed { get { return isAttackingPressed; } }
    
    



    public float CurrentMoveY { get { return currentMove.y; } set { currentMove.y = value; } }
    public float AppliedMoveY { get { return appliedMovement.y; } set { appliedMovement.y = value; } }
    public float GravityGrounded {  get { return groundGravity; } }
    public bool JumpPressed { get { return isJumping; } }
    public float AppliedMoveX { get { return appliedMovement.x; } set { appliedMovement.x = value; } }
    public float AppliedMoveZ { get { return appliedMovement.z; } set { appliedMovement.z = value; } }
    public float RunSpeed { get { return runSpeedMultiply; } }
    public float JumpVelocity { get { return jumpVelocity; } }
    public float Gravity { get { return gravity; } }


    public Vector2 CurrentMoveInput { get { return currentMoveInput; } }
   //public ParticleSystem Particle { get { return particle; } }

    void Awake()
    {

        // set reference variables
        playerControl = new PlayerControl();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();


        // setup states

        states = new PlayerStateFactory(this);
        currentState = states.Grounded();
        currentState.EnterState();

        //hash the animator parameter to speed up the performance  
        walkingHash = Animator.StringToHash("Walking");
        runningHash = Animator.StringToHash("Running");
        jumpingHash = Animator.StringToHash("Jumping");
        attackingHash = Animator.StringToHash("Attacking");
       
   

        // set player input callbacks
        playerControl.CharacterControls.Moves.started += OnMoveInput;
        playerControl.CharacterControls.Moves.canceled += OnMoveInput;
        playerControl.CharacterControls.Moves.performed += OnMoveInput;
        playerControl.CharacterControls.Run.started += OnRun;
        playerControl.CharacterControls.Run.canceled += OnRun;
        playerControl.CharacterControls.Jump.started += OnJump;
        playerControl.CharacterControls.Jump.canceled += OnJump;
        playerControl.CharacterControls.Attack.started += OnAttack;
        playerControl.CharacterControls.Attack.canceled += OnAttack;
        playerControl.CharacterControls.Attack.performed += OnAttack;
        playerControl.CharacterControls.Collect.started += OnCollect;
        playerControl.CharacterControls.Collect.canceled += OnCollect;




        setJumpVariables();
        


    }

    // setting jump height and duration, also velocity
    void setJumpVariables()
    {
        float apexTime = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(apexTime, 2);
        jumpVelocity = (2 * maxJumpHeight) / apexTime;
    }


    public void shoot()
    {

        attackSound.Play();

        Rigidbody rb = Instantiate(spell, spellPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
        rb.AddForce(transform.up * 6.5f, ForceMode.Impulse);

    }

    // ------------------ test function ---------------------------------------

    /*void takeGems()
    {
        

        if (theDistance <= 3)
        {
            actionDisplay.SetActive(true);
            actionText.SetActive(true);

        }
        else
        {
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
        }



        if (isCollecting == true)
        {

            collectSound.Play();
            magicPowerUp = true;
            MagicGem.SetActive(false);

            actionDisplay.SetActive(false);
            actionText.SetActive(false);

        }
       

    }*/

    /*
        if (isCollecting == true)
        {
            collectSound.Play();
            HealthGem.SetActive(false);
            HealthUp = true;
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
        }*/

// -----------------------------------------------------------------------------------------------------------------------------------




    // handle the rotation of the player to match camera view
    void charaterRotation()
    {
        Vector3 characterView;

        characterView.x = currentMoveInput.x;
        characterView.y = zero;
        characterView.z = currentMoveInput.y;

        characterView = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * characterView;
        Quaternion currentRotation = transform.rotation;

        if (characterView != Vector3.zero)
        {
        Quaternion targetDirection = Quaternion.LookRotation(characterView);
        transform.rotation = Quaternion.Slerp(currentRotation, targetDirection, rotationFactorEachFrame * Time.deltaTime);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    

    

    // Update is called once per frame
    void Update()
    {
     
        charaterRotation();
        currentState.UpdateStates();
        theDistance = playerCasting.DistanceFromTarget;
        //takeGems();
        
        

        appliedMovement = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * appliedMovement;
        characterController.Move(appliedMovement * Time.deltaTime);
    }

    
   void OnCollect(InputAction.CallbackContext context)
    {
        isCollecting = context.ReadValueAsButton();
    } 
   

    // jump button callback function
    void OnJump(InputAction.CallbackContext context)
    {
        isJumping = context.ReadValueAsButton();
    }

    // run button callback function
    void OnRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }


    // set player input values using callback function 
    void OnMoveInput(InputAction.CallbackContext context)
    {
        currentMoveInput = context.ReadValue<Vector2>();
        isMovePressed = currentMoveInput.x != zero || currentMoveInput.y != zero;
    }

    // attack button callback function
   void OnAttack(InputAction.CallbackContext context)
    {
        isAttackingPressed = context.ReadValueAsButton();

     

    }

    //enable character control action map
    void OnEnable()
    {
        playerControl.CharacterControls.Enable();
    }

    //disable character control action map 
    void OnDisable()
    {
        playerControl.CharacterControls.Disable();
    }
}
