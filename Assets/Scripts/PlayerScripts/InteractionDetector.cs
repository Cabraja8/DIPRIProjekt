using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionDetector : MonoBehaviour
{
    public List<Interactable> interactablesInRange = new List<Interactable>();
    public TextMeshProUGUI interactionText; // Reference to the TextMeshProUGUI element

    void Start()
    {
        // Ensure the interaction text is initially hidden
        interactionText.enabled = false;
    }

    void Update()
    {
        if (interactablesInRange.Count > 0)
        {
            interactionText.enabled = true; // Show the text when near an interactable

            if (Input.GetKeyDown(KeyCode.E))
            {
                var interactable = interactablesInRange[0];
                interactable.Interact();
                if (!interactable.CanInteract())
                {
                    interactablesInRange.Remove(interactable);
                }
            }
        }
        else
        {
            interactionText.enabled = false; // Hide the text when not near any interactables
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<Interactable>();

        if (interactable != null && interactable.CanInteract())
        {
            interactablesInRange.Add(interactable);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<Interactable>();

        if (interactablesInRange.Contains(interactable))
        {
            interactablesInRange.Remove(interactable);
        }
    }
}
