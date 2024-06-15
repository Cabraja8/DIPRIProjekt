using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, Interactable
{
    public StoneType stoneType;

    public void Interact()
    {
        Debug.Log("Stone Interacted: " + stoneType);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            if (inventory.stones.Count < inventory.maxCapacity)
            {
                inventory.AddStone(stoneType);
                Destroy(gameObject); // Destroy the stone GameObject after adding its type to the inventory
            }
            else
            {
                Debug.Log("Inventory is full. Cannot pick up more stones.");
            }
        }
    }

    public bool CanInteract()
    {
        return true;
    }
}

