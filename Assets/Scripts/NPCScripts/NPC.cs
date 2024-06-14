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
        agent.avoidancePriority = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


         public void MoveTo(Vector3 targetPosition, System.Action onReach)
    {
        agent.SetDestination(targetPosition);
        StartCoroutine(WaitForDestinationReached(onReach));
    }

    private IEnumerator WaitForDestinationReached(System.Action onReach)
    {
        while (agent.pathPending || agent.remainingDistance > 0.1f)
        {
            yield return null;
        }
        onReach?.Invoke();
    }
}
      
