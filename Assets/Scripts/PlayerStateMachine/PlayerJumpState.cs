using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) 
    {
        RootState = true;
        InitializeSubStates(); 
        
    }

    public override void EnterState() 
    {
        ManageJump();
    }

    public override void UpdateState()
    {
        Debug.Log("Jumpping");

        CheckSwitchStates();
        ManageGravity();
    }

    public override void ExitState()
    {

        Contxt.Animator.SetBool(Contxt.JumpHash, false);
    }

    public override void CheckSwitchStates() 
    {
        if (Contxt.CharacterController.isGrounded )
        {
            SwitchState(Factory.Grounded());

        } else if (Contxt.IsAttackingPressed)
        {
            SwitchState(Factory.Attack());
        }
        
       

    }

    public override void InitializeSubStates() 
    {

        if (!Contxt.MovePressed)
        {
            SetSubState(Factory.Idle());

        }
        else if (Contxt.MovePressed && !Contxt.RunPressed)
        {
            SetSubState(Factory.Walk());

        }
        else
        {
            SetSubState(Factory.Run());

        }
    }

    void ManageJump()
    {
        Contxt.Animator.SetBool(Contxt.JumpHash, true);
        Contxt.Jumping = true;
        Contxt.CurrentMoveY = Contxt.JumpVelocity;
        Contxt.AppliedMoveY = Contxt.JumpVelocity;
    }

    void ManageGravity()
    {
        bool isFalling = Contxt.CurrentMoveY <= 0.0f || !Contxt.IsJumping;
        float fallSpeed = 2.0f;

        // applies gravity depending if the player is grounded or not

        if (isFalling)
        {
            float oldVelocityY = Contxt.CurrentMoveY;
            Contxt.CurrentMoveY = Contxt.CurrentMoveY + (Contxt.Gravity * fallSpeed * Time.deltaTime);
            Contxt.AppliedMoveY = Mathf.Max((oldVelocityY + Contxt.CurrentMoveY) * .5f, -20.0f);


        }
        else
        {
            float oldVelocityY = Contxt.CurrentMoveY;
            Contxt.CurrentMoveY = Contxt.CurrentMoveY + (Contxt.Gravity * fallSpeed * Time.deltaTime);
            Contxt.AppliedMoveY = (oldVelocityY + Contxt.CurrentMoveY) * .5f;

        }
    }
}