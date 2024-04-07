using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithKnights : MonoBehaviour,Interactable
{   
    private bool Interacted;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

   
    public void Interact(){
        Interacted = true;
        Debug.Log("Talking with guards");
    }

    public bool CanInteract(){
        return !Interacted;
    }




}
