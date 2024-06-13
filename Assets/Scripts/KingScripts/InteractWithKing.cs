using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithKing : MonoBehaviour,Interactable
{   
    public bool IsInteracted;
   private DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
       
        dialogueTrigger = GetComponent<DialogueTrigger>(); // Get reference to DialogueTrigger script
    }

    public void Interact()
    {
        IsInteracted = true;
        Debug.Log("Talking with King");
        if (dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue(); // Call TriggerDialogue method from DialogueTrigger script
        }
    }

    public bool CanInteract(){
        Invoke("ResetInteraction",2f);
        return !IsInteracted;
    }

    public void ResetInteraction(){
        IsInteracted = false;
    }


   
}
