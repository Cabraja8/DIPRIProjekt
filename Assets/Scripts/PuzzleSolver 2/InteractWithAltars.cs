using UnityEngine;

public class InteractWithAltars : MonoBehaviour, Interactable
{
    public WeaponTypeStatues RequiredWeaponType;
    private bool isItemPlaced = false;
    public TriggerStatues triggerStatues;
    public GameObject altarVisualPrefab; // Prefab of the visual representation of the item on the altar

    public void Interact()
    {
        if (isItemPlaced) 
        {
            Debug.Log("Altar already has an item.");
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject not found!");
            return;
        }

        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogError("Inventory component not found on player GameObject!");
            return;
        }

        if (inventory.Weapons.Contains(RequiredWeaponType))
        {
            inventory.RemoveWeapon(RequiredWeaponType);
            isItemPlaced = true;
            Debug.Log("Item placed on the correct altar.");

            // Instantiate the altar visual prefab at the altar's position
            if (altarVisualPrefab != null)
            {   
                UnityEngine.Rendering.Universal.Light2D light2D = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();

        if (light2D != null)
        {
            // Disable the Light2D component
            light2D.enabled = false;
        }
                Instantiate(altarVisualPrefab, transform.position, Quaternion.identity);
                // You may need to adjust the position and rotation depending on where you want to place the visual
            }

            if (triggerStatues != null)
            {
                triggerStatues.EnableLastDoor();
            }
            else
            {
                Debug.LogError("triggerStatues is not assigned in the Inspector!");
            }
        }
        else
        {
            Debug.Log("Cannot put this item on this altar.");
        }
    }

    public bool CanInteract()
    {   
    
        return !isItemPlaced;
    }
}



