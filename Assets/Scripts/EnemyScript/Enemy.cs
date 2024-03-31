using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour{
    public Transform target;

    [Header("Default Values for Tweaking")]
    public float speed = 5f; 
    public float stopDistance = 2f;
    public float attackTime;
    public float attackSpeed;
    public float TimeBetweenAttacks;
    public NavMeshAgent navMeshAgent;
    public CombatAndMovement enemyAnimation;
    private SpriteRenderer rend;
    
    protected virtual void Start(){
        target = GameObject.FindWithTag("Player").transform;
        enemyAnimation = GetComponentInChildren<CombatAndMovement>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rend = GetComponentInChildren<SpriteRenderer>();
        SetDefaultValues();
    }

    private void SetDefaultValues(){
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

     protected virtual void Update()
    {
        WalkEnemyAnim();
        CheckAngle();
        
    }

    private void CheckAngle()
    {   
        
        Vector3 directionToTarget = target.position - transform.position;
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

    private void WalkEnemyAnim(){
    if (navMeshAgent.velocity.magnitude > 0.1f)
    {    
        enemyAnimation.PlayWalkAnimation();
    }
    else
    {
        enemyAnimation.StopWalkAnimation();
    }
}

  


}
