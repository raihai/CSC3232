using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    // substate 

    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

    // active idle animation, stop player movement
    public override void EnterState()
    {
        Contxt.Animator.SetBool(Contxt.WalkingHash, false);
        Contxt.Animator.SetBool(Contxt.RunningHash, false);

        Contxt.Walk.Stop();
        Contxt.Run.Stop();

        Contxt.AppliedMoveX = 0;
        Contxt.AppliedMoveZ = 0;

    }

    public override void UpdateState()
    {
        CheckSwitchStates();
       
    }

    public override void ExitState()
    {
      
    }

    public override void InitializeSubStates()
    {

    }

    // switch state depending on user input 
    public override void CheckSwitchStates()
    {

        if (Contxt.MovePressed && !Contxt.RunPressed)
        {
            SwitchState(Factory.Walk());

        }

        else if (Contxt.MovePressed && Contxt.RunPressed)
        {
            SwitchState(Factory.Run());
        }
        

        

        


    }


}
