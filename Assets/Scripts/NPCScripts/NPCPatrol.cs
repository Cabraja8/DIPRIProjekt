using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : NPC
{
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;
    private NavMeshAgent agent;

    public bool  IsIdle;
    public float waitTime = 2f; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; 
        agent.updateUpAxis = false; 

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    private IEnumerator WaitAtPoint()
    {
      
        yield return new WaitForSeconds(waitTime); 
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPointIndex].position);
       
    }
}
