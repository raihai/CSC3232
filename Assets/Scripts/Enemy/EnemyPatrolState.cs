using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : StateMachineBehaviour
{
    float timer;
    List<Transform> patrolPoints = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    float chaseTriggerRange = 15;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform patrolPointsObject = GameObject.FindGameObjectWithTag("PatrolPoints").transform;
        foreach (Transform i in patrolPointsObject) { 
        patrolPoints.Add(i); }

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPoints[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // State Control

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
        //

        if (agent.remainingDistance <= agent.stoppingDistance)
        { 
         agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Count)].position); 
        }
        timer += Time.deltaTime;
        if (timer > 20)
        {
            animator.SetBool("Patrol", false);
        }


        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseTriggerRange)
        {
            animator.SetBool("Chasing", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
