using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCKnightBehaviour : NPCBehaviour, Interactable
{   
    private bool Interacted;
  
    public Transform target;

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



   
}
