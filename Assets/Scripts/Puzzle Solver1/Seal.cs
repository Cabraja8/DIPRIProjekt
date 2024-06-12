using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour, Interactable
{   
    public bool Interacted;
    public List<StoneType> requiredStoneTypes;
    private List<StoneType> placedStoneTypes = new List<StoneType>();

    public void Interact()
    {   
        Interacted = true;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            foreach (GameObject stone in inventory.stones)
            {
                Stone stoneScript = stone.GetComponent<Stone>();
                if (stoneScript != null && requiredStoneTypes.Contains(stoneScript.stoneType))
                {
                    placedStoneTypes.Add(stoneScript.stoneType);
                    inventory.stones.Remove(stone);
                    Destroy(stone);
                    break;
                }
            }

            if (CheckIfPuzzleSolved())
            {
                OpenSeal();
            }
        }
    }

    public bool CanInteract()
    {
        Invoke("ResetInteraction",2f);
        return !Interacted;
    }

    private bool CheckIfPuzzleSolved()
    {
        foreach (StoneType type in requiredStoneTypes)
        {
            if (!placedStoneTypes.Contains(type))
            {
                return false;
            }
        }
        return true;
    }

    private void OpenSeal()
    {   
        Debug.Log("Seal Opened!");
        
    }


    public void ResetInteraction(){
        Interacted = false;
    }
}
