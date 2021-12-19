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


    // When enemy reaches partol point, it randomly choose another point to walk towards. The patrol state last for
    // 20 seconds then it reverts back to idle state unless it detects the player then it changes to chase state

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
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


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
