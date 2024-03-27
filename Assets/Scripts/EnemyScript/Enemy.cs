using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
   public Transform target; 

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            Debug.LogError("Target is not set for enemy!");
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, 0f);
            navMeshAgent.SetDestination(targetPosition);
        }
    }
}
