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
            inventory.AddStone(gameObject);
            Destroy(gameObject);
        }
    }

    public bool CanInteract()
    {
        return true;
    }
}
