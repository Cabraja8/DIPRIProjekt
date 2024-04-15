using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

     public CombatAndMovement NPCAnimation;
     public NavMeshAgent navMeshAgent;
     public float speed = 5f; 
    GameObject standField;

    private SpriteRenderer rend;
    public Transform Target; 
    public float stopDistance = 2f;
   protected virtual void Start()
    {
        NPCAnimation = GetComponentInChildren<CombatAndMovement>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rend = GetComponentInChildren<SpriteRenderer>();
        SetDefaultValues();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found.");
        }
        standField = GameObject.FindGameObjectWithTag("StartField");
    if (standField != null) {
        navMeshAgent.SetDestination(standField.transform.position);
    } 

        
    }
     private void SetDefaultValues(){
      
            navMeshAgent.updateRotation = false;
            navMeshAgent.stoppingDistance = stopDistance;
            navMeshAgent.speed = speed;
        
    }
 

    // Update is called once per frame
    protected virtual void Update()
    {   
        WalkingNPCAnim();
        if(Target !=null){

        CheckAngle();
        }else{
            CheckAngleForWalking();
        }
    }

    private void CheckAngle()
    {   
        
        Vector3 directionToTarget = Target.position - transform.position;
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
    private void CheckAngleForWalking()
    {   
        
        Vector3 directionToTarget = standField.transform.position - transform.position;
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

      private void WalkingNPCAnim(){
    if (navMeshAgent.velocity.magnitude > 0.1f)
    {    
        NPCAnimation.PlayWalkAnimation();
    }
    else
    {
        NPCAnimation.StopWalkAnimation();
    }
       }
    
}
