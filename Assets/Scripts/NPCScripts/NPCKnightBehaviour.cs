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

   protected override void Start()
    {    
        base.Start();
        Interacted = true; // ovo trebam reworkat
    }

    protected override void Update()
    {      
      base.Update();
    
    DetectTarget();
    if(Target !=null){

    IfInRangeAttack();
    }
    if (Target == null)
    {
        return;
    }

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

//    public IEnumerator Attack()
//     {
//         Vector2 originalPosition = transform.position;
//         Vector2 targetPosition = Target.position;
//         float percent = 0;

//         while (percent <= 1)
//         {
//             percent += Time.deltaTime * attackSpeed;
//             float smoothPercent = Mathf.SmoothStep(0f, 1f, percent);
//             float formula = (-Mathf.Pow(smoothPercent, 1) + smoothPercent) * 4;
//             transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            
//             yield return null;
//         }
//     }



    // za sad ovo pa cu kasnije izmjenit
     public void Interact(){
        Interacted = true;
        Debug.Log("Talking with guards");
    }

    public bool CanInteract(){
        return !Interacted;
    }
   
}
