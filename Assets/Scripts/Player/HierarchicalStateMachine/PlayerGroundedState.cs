using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    //superstate
    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory)
    {
        RootState = true;
        InitializeSubStates();
      
    }

   
    public override void EnterState() {
        Contxt.CurrentMoveY = Contxt.GravityGrounded;
        Contxt.AppliedMoveY = Contxt.GravityGrounded;
  

    }

    public override void UpdateState() 
    {
        CheckSwitchStates();
       
    }

    public override void ExitState() { }



    public override void InitializeSubStates() 
    {

        // initialize substate depending on the player input 

        if (!Contxt.MovePressed )
        {
            SetSubState(Factory.Idle());

        }
        else if (Contxt.MovePressed && !Contxt.RunPressed )
        {
            SetSubState(Factory.Walk());

        }
        else if(Contxt.MovePressed && Contxt.RunPressed )
        {
            SetSubState(Factory.Run());

        }


    }

    public override void CheckSwitchStates()
    {

        // change to attack or jump state if they are pressed while grounded

        if (Contxt.JumpPressed )
        {
            SwitchState(Factory.Jump());
        } else if (Contxt.IsAttackingPressed && !Contxt.MovePressed)
        {
           
            SwitchState(Factory.Attack());
        }
        
    }



  

    
}
