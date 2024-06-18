using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCrown : MonoBehaviour, Interactable
{   
     public bool Interacted;
    public void Interact(){
        Interacted = true;
        Debug.Log("Crown taken");
    }
    public bool CanInteract(){
        return !Interacted;
    }
    
}
