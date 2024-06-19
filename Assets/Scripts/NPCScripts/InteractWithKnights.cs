using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithKnights : MonoBehaviour, Interactable
{
    private bool Interacted;
    private DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        dialogueTrigger = GetComponent<DialogueTrigger>(); // Get reference to DialogueTrigger script
    }

    public void Interact()
    {
        Interacted = true;
        Debug.Log("Talking with guards");
        if (dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue(); // Call TriggerDialogue method from DialogueTrigger script
        }
    }

    public bool CanInteract()
    {
        return !Interacted;
    }
}
