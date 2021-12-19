
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : StateMachineBehaviour
{

    float timer;
    
    Transform player;
    float chaseTriggerRange = 25;

   


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // stays idle for five seconds then changes to patrol state unless it detects the player

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       

        timer += Time.deltaTime;
        if (timer > 5)
        {
            animator.SetBool("Patrol", true);
        }

        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < chaseTriggerRange)
        {
            animator.SetBool("Chasing", true);
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }


    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
     
    }
}
