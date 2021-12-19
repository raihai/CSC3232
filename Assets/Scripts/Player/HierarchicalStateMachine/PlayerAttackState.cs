using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    //sub state

    
    public float range = 30f;
    public float impactForce = 150;


    public PlayerAttackState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
        RootState = true;
    }


    // activate attack animation 
    public override void EnterState() {

        Contxt.Animator.SetBool(Contxt.AttackingHash, true);
    }

    public override void UpdateState() 
    {
     
        CheckSwitchStates();
        Debug.Log("attacking");
  
    }

    public override void ExitState() 
    {
        Contxt.Animator.SetBool(Contxt.AttackingHash, false);

    }


    public override void CheckSwitchStates()
    {
       SwitchState(Factory.Grounded());
     
    }

    public override void InitializeSubStates()
    {
        

    }

    
   


}
