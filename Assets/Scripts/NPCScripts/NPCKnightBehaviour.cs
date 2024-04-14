using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCKnightBehaviour : NPCBehaviour, Interactable
{   
    private bool Interacted;
  
    public Transform target;
    public float detectionRadius = 5f;
    public LayerMask targetLayerMask;

   protected override void Start()
    {    
         GameObject standField = GameObject.FindGameObjectWithTag("StartField");
    if (standField != null) {
        Target = standField.transform;
    } 
        base.Start();
        Interacted = true;

        Invoke("AttackEnemy",2f);
    
    }

    protected override void Update()
    {      
        base.Update();
        
        
    }


    // za sad ovo pa cu kasnije izmjenit
     public void Interact(){
        Interacted = true;
        Debug.Log("Talking with guards");
    }

    public bool CanInteract(){
        return !Interacted;
    }


    public void AttackEnemy(){
        target = GameObject.FindWithTag("Enemy").transform;
        navMeshAgent.SetDestination(target.position);
    }

    protected virtual void DetectTarget()
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, targetLayerMask);
    foreach (Collider2D collider in colliders)
    {
        if (collider.CompareTag("Enemy"))
        {
            SetTarget(collider.transform);
            Debug.Log("Target detected: " + collider.name); // Add this line for debugging
            break;
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


 public virtual void SetTarget(Transform newTarget)
{   
    target = newTarget;
    if (target != null)
    {
        navMeshAgent.SetDestination(target.position);
    }
}
   
}
