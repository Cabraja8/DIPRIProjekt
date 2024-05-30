using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;


public class NPCBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

     public CombatAndMovement NPCAnimation;
     public NavMeshAgent navMeshAgent;
     public float speed = 5f; 
   public GameObject standField;

    private SpriteRenderer rend;
    public Transform Target; 
    public float stopDistance = 2f;
    
    

   protected virtual void Start()
    {
        NPCAnimation = GetComponentInChildren<CombatAndMovement>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rend = GetComponentInChildren<SpriteRenderer>();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found.");
        }
        
        SetDefaultValues();
        
            FirstSceneKnightCall();
            
    }

    public void FirstSceneKnightCall(){

    standField = GameObject.FindGameObjectWithTag("StartField");
    if (standField != null) {
        GetComponent<NPCKnightBehaviour>().GoToDestination(standField.transform);
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
        CheckAngle();
        
    }

 private void CheckAngle()
{
   
    if (Target != null)
    {

        Vector3 directionToTarget = Target.position - transform.position;
    
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
