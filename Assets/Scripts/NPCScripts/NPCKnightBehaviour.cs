using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCKnightBehaviour : MonoBehaviour
{
   public Transform StandField; // Set this to the destination GameObject or position

    private NavMeshAgent navMeshAgent;
    public Vector2 MoveAmount;

     public CombatAndMovement KnightAnimation;
     public float speed = 5f; 
    public float stopDistance = 2f;
    private SpriteRenderer rend;

    void Start()
    {   
        KnightAnimation = GetComponentInChildren<CombatAndMovement>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rend = GetComponentInChildren<SpriteRenderer>();
        SetDefaultValues();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found.");
        }
        else if (StandField == null)
        {
            Debug.LogError("Target destination not set.");
        }
        else
        {
            SetDestination();
        }
    }

    void SetDestination()
    {
        navMeshAgent.SetDestination(StandField.position);
    }

     private void SetDefaultValues(){
        if (StandField == null)
        {
            Debug.LogError("Target is not set for enemy!");
        }
        else
        {
            navMeshAgent.updateRotation = false;
            //navMeshAgent.stoppingDistance = stopDistance;
            navMeshAgent.speed = speed;
        }
    }

     void Update()
    {   
        CheckWalkingAnimation();
        CheckAngle();
        
    }


public void CheckWalkingAnimation()
    {
    Vector2 currentPosition = transform.position;
        float distance = Vector2.Distance(currentPosition, MoveAmount);

        if (distance > 0.01f)
        {
            KnightAnimation.PlayWalkAnimation();
        }
        else
        {
            KnightAnimation.StopWalkAnimation();
        }
}

    private void CheckAngle()
    {   
        
        Vector3 directionToTarget = StandField.position - transform.position;
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        if (angle >= 90 || angle <= -90)
        {
            rend.flipX = true;
        }
        else
        {
            rend.flipX = false;
        }
    }
}
