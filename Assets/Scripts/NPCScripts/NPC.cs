using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public bool  IsIdle; // If idle don't patrol

    public NavMeshAgent agent;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; 
        agent.updateUpAxis = false; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     public void MoveTo(Vector3 destination, System.Action onDestinationReached)
    {
        agent.SetDestination(destination);
        StartCoroutine(CheckIfReachedDestination(onDestinationReached));
    }

    private IEnumerator CheckIfReachedDestination(System.Action onDestinationReached)
    {
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }
    }
}
      
