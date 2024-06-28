using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
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

    public bool CanDetectFromFar=true;

    public GameObject HealthBarUI;

    private List<Transform> targets = new List<Transform>();
    public float maxHealth = 100f;
    private float currentHealth;
    protected virtual void Start()
    {
        //target = GameObject.FindWithTag("Player").transform;
        enemyAnimation = GetComponentInChildren<CombatAndMovement>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rend = GetComponentInChildren<SpriteRenderer>();
        SetDefaultValues();
    }

    private void SetDefaultValues()
    {

        navMeshAgent.updateRotation = false;
        navMeshAgent.stoppingDistance = stopDistance;
        navMeshAgent.speed = speed;

    }

    protected virtual void Update()
    {

        WalkEnemyAnim();
        CheckAngle();

        if(!CanDetectFromFar){
        DetectTarget();
        }else{
        if (target == null)
        {
            target = FindClosestTarget(transform.position, "Player", "Knight");
        }
        }
    }
    Transform FindClosestTarget(Vector3 position, params string[] tags)
    {
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (string tag in tags)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject target in targets)
            {
                float distanceToTarget = Vector3.Distance(position, target.transform.position);
                if (distanceToTarget < closestDistance)
                {
                    closestTarget = target.transform;
                    closestDistance = distanceToTarget;
                }
            }
        }

        return closestTarget;
    }


    public virtual void SetTarget(Transform newTarget)
    {
        target = newTarget;

    }

    private void CheckAngle()
    {

        if (target != null)
        {

            Vector3 directionToTarget = target.position - transform.position;

            Vector3 localDirection = transform.InverseTransformDirection(directionToTarget);

            float angle = Mathf.Atan2(localDirection.y, localDirection.x) * Mathf.Rad2Deg;

            if (angle >= 90 || angle <= -90)
            {
                rend.flipX = true;
            }
            else
            {
                rend.flipX = false;
            }
        }
        else
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float direction = Mathf.Sign(Vector3.Cross(transform.forward, localVelocity).y);

            if (direction > 0)
            {

                rend.flipX = false;
            }
            else if (direction < 0)
            {

                rend.flipX = true;
            }
        }
    }

    private void WalkEnemyAnim()
    {
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


    public void DeathHandler()
    {
        GetComponentInChildren<CombatAndMovement>().DeathAnimation();
        this.gameObject.tag = "Dead";
        this.gameObject.layer = 8;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Enemy>().enabled = false;
        HealthBarUI.SetActive(false);
        Destroy(gameObject, 2.5f);

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DeathHandler();
        }
    }

    public void onHit(float damage)
    {
        Debug.Log("swordbox hit" + damage);
    }

}
