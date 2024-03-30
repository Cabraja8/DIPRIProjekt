using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour{
    public Transform target;

    [Header("Default Values for Tweaking")]
    public float speed = 5f; 
    public float stopDistance = 2f;
    private float attackTime;
    public float attackSpeed;
    public float TimeBetweenAttacks;
    private NavMeshAgent navMeshAgent;
    private CombatAndMovement enemyAnimation;
    private SpriteRenderer rend;
    
    void Start(){
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

    void Update()
    {
        WalkEnemyAnim();
        CheckAngle();
        if (target != null)
        {
            AttackIfInRange();
        }
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

    private void AttackIfInRange(){
        navMeshAgent.SetDestination(target.position);
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.position.x, target.position.y)) <= stopDistance)
{
    if (Time.time >= attackTime)
    {
        StartCoroutine(Attack());
        attackTime = Time.time + TimeBetweenAttacks;
        enemyAnimation.StopWalkAnimation();
    }
}
    }



   IEnumerator Attack(){
    Vector2 originalPosition = transform.position;
    Vector2 targetPosition = target.position;
    float percent = 0;
    Debug.Log("Attack");
    enemyAnimation.PlayAttackAnimation();

    while (percent <= 1)
    {
        percent += Time.deltaTime * attackSpeed;
        float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
        transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
        yield return null;
    }
}
}
