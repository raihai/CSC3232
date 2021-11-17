using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

    public override void EnterState() 
    {
        Contxt.Animator.SetBool(Contxt.WalkingHash, true);
        Contxt.Animator.SetBool(Contxt.RunningHash, true);
        Contxt.Animator.SetBool(Contxt.AttackingHash, false);


    }

    public override void UpdateState()
    {


        CheckSwitchStates();
        Contxt.AppliedMoveX = Contxt.CurrentMoveInput.x * Contxt.RunSpeed;
        Contxt.AppliedMoveZ = Contxt.CurrentMoveInput.y * Contxt.RunSpeed;

        ManageGravity();
    }

    public override void ExitState() {
        Contxt.Animator.SetBool(Contxt.RunningHash, false);
    }

    public override void InitializeSubStates()
    {

    }

    public override void CheckSwitchStates() 
    {
        if (!Contxt.MovePressed && !Contxt.RunPressed )
        {
            SwitchState(Factory.Idle());

        }

        else if (Contxt.MovePressed && !Contxt.RunPressed )
        {
            SwitchState(Factory.Walk());
        }
        else if (!Contxt.MovePressed && Contxt.RunPressed )
        {
            SwitchState(Factory.Walk());
        }



    }

    void ManageGravity()
    {
       
        float fallSpeed = .5f;

        // applies gravity depending if the player is grounded or not

            float oldVelocityY = Contxt.CurrentMoveY;
            Contxt.CurrentMoveY = Contxt.CurrentMoveY + (Contxt.Gravity * fallSpeed * Time.deltaTime);
            Contxt.AppliedMoveY = (oldVelocityY + Contxt.CurrentMoveY) * .5f;

       
    }
}
