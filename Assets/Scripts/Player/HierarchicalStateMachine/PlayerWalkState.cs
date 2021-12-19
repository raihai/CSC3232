using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{

    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }
   
    // play walk animation 
    public override void EnterState() 
    {
        Contxt.Animator.SetBool(Contxt.WalkingHash, true);
        Contxt.Animator.SetBool(Contxt.RunningHash, false);
        Contxt.Animator.SetBool(Contxt.AttackingHash, false);

        Contxt.Walk.Play();
        Contxt.Run.Stop();

    }

    // apply walk force
    public override void UpdateState()
    {

        CheckSwitchStates();
        Contxt.AppliedMoveX = Contxt.CurrentMoveInput.x * 2.0f;
        Contxt.AppliedMoveZ = Contxt.CurrentMoveInput.y * 2.0f;
        
        ManageGravity();
    }

    public override void ExitState() { }

    public override void CheckSwitchStates() 
    {
        if (!Contxt.MovePressed )
        {
            SwitchState(Factory.Idle());

        }
        else if (Contxt.MovePressed && Contxt.RunPressed )
        {
            SwitchState(Factory.Run());
        }
      
  


    }

    public override void InitializeSubStates() 
    {
    }

    void ManageGravity()
    {
     
        float fallSpeed = 1f;

        // applies gravity depending if the player is grounded or not

     
            float oldVelocityY = Contxt.CurrentMoveY;
            Contxt.CurrentMoveY = Contxt.CurrentMoveY + (Contxt.Gravity * fallSpeed * Time.deltaTime);
            Contxt.AppliedMoveY = (oldVelocityY + Contxt.CurrentMoveY) * .5f;

        
    }



}
