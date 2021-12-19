using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    // super state

    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) 
    {
        RootState = true;
        InitializeSubStates(); 
        
    }

    // activate jump animation
    public override void EnterState() 
    {
        ManageJump();
        Contxt.Walk.Stop();
        Contxt.Run.Stop();
        Contxt.Jump.Play();
    }

    // check switch state, enforce gravity forece upon player
    public override void UpdateState()
    {
        CheckSwitchStates();
        ManageGravity();
    }

    // disable jump animation upon state switch
    public override void ExitState()
    {
        Contxt.Animator.SetBool(Contxt.JumpHash, false);
    }

    // check state change
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

    // change state depending on user input 
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

    // activate jump with force 
    void ManageJump()
    {
        Contxt.Animator.SetBool(Contxt.JumpHash, true);
        Contxt.Jumping = true;
        Contxt.CurrentMoveY = Contxt.JumpVelocity;
        Contxt.AppliedMoveY = Contxt.JumpVelocity;
    }

    // enforce gravity on player when they jump
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
