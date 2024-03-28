using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5f; 
    public float stopDistance = 2f;

    private float attackTime;
    public float attackSpeed;
    public float TimeBetweenAttacks;
    private NavMeshAgent navMeshAgent;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            Debug.LogError("Target is not set for enemy!");
        }
        else
        {
            navMeshAgent.updateRotation = false;
            navMeshAgent.stoppingDistance = stopDistance;
            navMeshAgent.speed = speed; 
        }
    }

    void Update()
    {   
 
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
            
            if(Time.time >=attackTime){
                StartCoroutine(Attack());
                attackTime = Time.time + TimeBetweenAttacks;
            }
        }
    }

    

    IEnumerator Attack(){
        
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = target.position;
        float percent = 0;
        Debug.Log("Attack");

        // while(percent <= 1){
        //     percent += Time.deltaTime * attackSpeed;
        //     float formula = (-Mathf.Pow(percent,2)+percent)*4;
        //     transform.position = Vector2.Lerp(originalPosition,targetPosition,formula);
            yield return null;
        //}
    }
}
