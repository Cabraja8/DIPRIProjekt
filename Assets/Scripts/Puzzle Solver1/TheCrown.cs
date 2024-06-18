using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCrown : MonoBehaviour, Interactable
{
    public bool Interacted;

    public AncientRuinsWaveSpawner ruins;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Interact called on TheCrown");
        if (!Interacted)
        {
            Interacted = true;
            Debug.Log("Interacted set to true");

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Debug.Log("Player found");
        
                Inventory inventory = player.GetComponent<Inventory>();
                if (inventory != null)
                {
                    Debug.Log("Inventory found, adding crown");
                    inventory.AddCrown(gameObject);
                    ruins.StartSpawning();
                    // Verify if the item is added to the inventory
                    if (inventory.Contains(gameObject))
                    {
                        Debug.Log("Crown successfully added to inventory");
                    }
                    else
                    {
                        Debug.LogWarning("Crown not found in inventory after adding");
                    }

                    // Disable the crown object and its CircleCollider2D
                    CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
                    if (collider != null)
                    {
                        collider.enabled = false;
                    }
                    gameObject.SetActive(false);

                    Debug.Log("Crown taken and disabled");
                }
                else
                {
                    Debug.LogWarning("Inventory component not found on player.");
                }
            }
            else
            {
                Debug.LogWarning("Player object not found.");
            }
        }
        else
        {
            Debug.Log("Crown already interacted with");
        }
    }

    public bool CanInteract()
    {
        return !Interacted;
    }
}

