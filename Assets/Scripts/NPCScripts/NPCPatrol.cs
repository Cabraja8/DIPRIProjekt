using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : NPC
{
    public Transform[] patrolPoints;
    private NavMeshAgent agent;

    public float waitTime = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Find all patrol points by tag
        GameObject[] patrolPointObjects = GameObject.FindGameObjectsWithTag("PatrolPoint");
        patrolPoints = new Transform[patrolPointObjects.Length];
        for (int i = 0; i < patrolPointObjects.Length; i++)
        {
            patrolPoints[i] = patrolPointObjects[i].transform;
        }

        if (patrolPoints.Length > 0)
        {
            SetRandomDestination();
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
        SetRandomDestination();
    }

    private void SetRandomDestination()
    {
        if (patrolPoints.Length == 0)
            return;

        int randomIndex = Random.Range(0, patrolPoints.Length);
        agent.SetDestination(patrolPoints[randomIndex].position);
    }
}
