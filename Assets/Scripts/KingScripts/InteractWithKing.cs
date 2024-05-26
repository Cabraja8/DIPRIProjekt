using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithKing : MonoBehaviour,Interactable
{   
    public bool IsInteracted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(){
        Debug.Log("Talking with King");
    }

    public bool CanInteract(){
        Invoke("ResetInteraction",2f);
        return !IsInteracted;
    }

    public void ResetInteraction(){
        IsInteracted = false;
    }
}
