using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : NPC
{
    public Transform[] patrolPoints;
    private NavMeshAgent patrolAgent; // Renamed from 'agent' to 'patrolAgent'

    public float waitTime = 2f;

    void Start()
    {
        patrolAgent = GetComponent<NavMeshAgent>(); // Adjusted to 'patrolAgent'

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
        if (!patrolAgent.pathPending && patrolAgent.remainingDistance < 0.1f) // Adjusted to 'patrolAgent'
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
        patrolAgent.SetDestination(patrolPoints[randomIndex].position); // Adjusted to 'patrolAgent'
    }
}