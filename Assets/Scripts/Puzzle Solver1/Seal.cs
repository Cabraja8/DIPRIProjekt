using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour, Interactable
{
    public bool Interacted;
    public List<StoneType> requiredStoneTypes;
    public int requiredStoneCount; // Number of correct stones needed to open the seal
    private List<StoneType> placedStoneTypes = new List<StoneType>();

    public void Interact()
    {
        Interacted = true;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            List<StoneType> stonesToRemove = new List<StoneType>();

            foreach (StoneType stoneType in inventory.stones)
            {
                if (requiredStoneTypes.Contains(stoneType))
                {
                    placedStoneTypes.Add(stoneType);
                    stonesToRemove.Add(stoneType);
                    if (placedStoneTypes.Count >= requiredStoneCount)
                    {
                        break; // Stop placing stones once the required count is reached
                    }
                }
                else
                {
                    Debug.Log("This stone doesn't fit.");
                }
            }

            foreach (StoneType stoneType in stonesToRemove)
            {
                inventory.RemoveStone(stoneType);
            }

            if (CheckIfPuzzleSolved())
            {
                OpenSeal();
            }
        }
    }

    public bool CanInteract()
    {
        Invoke("ResetInteraction", 2f);
        return !Interacted;
    }

    private bool CheckIfPuzzleSolved()
    {
        if (placedStoneTypes.Count < requiredStoneCount)
        {
            return false;
        }

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
        // Add more logic here if needed to handle the seal opening
    }

    public void ResetInteraction()
    {
        Interacted = false;
    }
}



