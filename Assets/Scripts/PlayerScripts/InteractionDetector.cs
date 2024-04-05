using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{   

    public List<Interactable> interactablesInRange = new List<Interactable>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E) && interactablesInRange.Count >0)
        {
            var interactable = interactablesInRange[0];
            interactable.Interact();
            if(!interactable.CanInteract()){
                interactablesInRange.Remove(interactable);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        var interactable = other.GetComponent<Interactable>();

        if(interactable != null && interactable.CanInteract() ){
        
            interactablesInRange.Add(interactable);
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<Interactable>();

        if(interactablesInRange.Contains(interactable)){
            interactablesInRange.Remove(interactable);
        }
    }

}
