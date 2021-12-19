using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrbitPlayer : MonoBehaviour
{
    public Transform player;
    NavMeshAgent nav;
    
    // pet follow player

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        nav.SetDestination(player.position);
    }


}
