using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCKnightBehaviour : NPCBehaviour, Interactable
{   
    private bool Interacted;
  
    public float detectionRadius = 5f;
    public LayerMask targetLayerMask;
    
    public float attackTime;
    public float attackSpeed;
    public float TimeBetweenAttacks;

    public int Damage;

    public GameObject HealthBarUI;

    public Transform Player;

    public bool CanDetectFromFar=false;
    public bool isFollowing = false;

   protected override void Start()
    {    
        base.Start();
        Interacted = true; // ovo trebam reworkat
        CanDetectFromFar=false;
        Player = FindObjectOfType<Player>().transform;
        
    }

    protected override void Update()
    {      
      base.Update();
    if(isFollowing){
        FollowPlayer();
    }
    if(CanDetectFromFar){
        DetectTarget();
        }else{
        if (Target == null)
        {
            Target  = FindClosestTarget(transform.position, "Enemy");
        return;
        }
        }
    if(Target !=null){
    isFollowing = false;
    IfInRangeAttack();
    }


    }
     Transform FindClosestTarget(Vector3 position, params string[] tags) {
    Transform closestTarget = null;
    float closestDistance = Mathf.Infinity;

    foreach (string tag in tags) {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in targets) {
            float distanceToTarget = Vector3.Distance(position, target.transform.position);
            if (distanceToTarget < closestDistance) {
                closestTarget = target.transform;
                closestDistance = distanceToTarget;
            }
        }
    }

    return closestTarget;
}

    protected virtual void DetectTarget()
{   
    Debug.Log("Detecting target "); 
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, targetLayerMask);
    foreach (Collider2D collider in colliders)
    {
        if (collider.CompareTag("Enemy"))
        {
            SetTarget(collider.transform);
            Debug.Log("Target detected: " + collider.name); 
            return;
        }
    }
}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


 public virtual void SetTarget(Transform newTarget)
{   
    Target = newTarget;
}   

public void GoToDestination(Transform Destination){
    navMeshAgent.SetDestination(Destination.transform.position);
}

public void FollowPlayer(){
   if (Player != null) 
        {
            navMeshAgent.SetDestination(Player.position);
        }
}

    public void IfInRangeAttack(){
        navMeshAgent.SetDestination(Target.position);
        if (Vector2.Distance(transform.position, Target.position) <= stopDistance)
        {
            if (Time.time >= attackTime)
            {   
                if(Target.GetComponent<HealthManager>().currentHealth > 1){

                NPCAnimation.PlayAttackAnimation();
                Debug.Log("Attack");
                Target.GetComponent<HealthManager>().TakeDamage(Damage);
                attackTime = Time.time + TimeBetweenAttacks;
                }else if(Target.GetComponent<HealthManager>().currentHealth < 1) {
                   DetectTarget();
                }
            }
        }
    }
    public void DeathHandler(){
        GetComponentInChildren<CombatAndMovement>().DeathAnimation();
        this.gameObject.tag = "Dead";
        this.gameObject.layer = 8;
        GetComponent<NPCBehaviour>().enabled =false;
        HealthBarUI.SetActive(false);
    }




    // za sad ovo pa cu kasnije izmjenit
     public void Interact(){
        Interacted = true;
        Debug.Log("Talking with guards");
    }

    public bool CanInteract(){
        return !Interacted;
    }
   
}
