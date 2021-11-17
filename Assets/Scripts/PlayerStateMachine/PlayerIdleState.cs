using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState

{
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }


    public override void EnterState()
    {
        Contxt.Animator.SetBool(Contxt.WalkingHash, false);
        Contxt.Animator.SetBool(Contxt.RunningHash, false);
        

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
