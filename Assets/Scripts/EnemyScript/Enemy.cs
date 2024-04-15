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

     [Header("Detection Settings")]
    public float detectionRadius = 5f;
    public LayerMask targetLayerMask;

    private List<Transform> targets = new List<Transform>();
    
    protected virtual void Start(){
        target = GameObject.FindWithTag("Player").transform;
        enemyAnimation = GetComponentInChildren<CombatAndMovement>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rend = GetComponentInChildren<SpriteRenderer>();
        SetDefaultValues();
    }

    private void SetDefaultValues(){
       
            navMeshAgent.updateRotation = false;
            navMeshAgent.stoppingDistance = stopDistance;
            navMeshAgent.speed = speed;

    }

     protected virtual void Update()
    {
        WalkEnemyAnim();
        CheckAngle();
       
        if (target == null)
        {
            DetectTarget();
         
        }
    }

   
   public virtual void SetTarget(Transform newTarget)
{   
    target = newTarget;
    
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


protected virtual void DetectTarget()
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, targetLayerMask);
    foreach (Collider2D collider in colliders)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Knight"))
        {
            SetTarget(collider.transform);
            Debug.Log("Target detected: " + collider.name); 
           return;
        }
    }
}


     protected virtual void GoTowardsTarget()
    {
        
    }
  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
  


}
