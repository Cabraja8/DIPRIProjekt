using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour, Interactable
{
    public bool Interacted;
    public List<StoneType> requiredStoneTypes;
    public int requiredStoneCount; // Number of correct stones needed to open the seal
    private List<StoneType> placedStoneTypes = new List<StoneType>();

    public GameObject stonePlacementIndicator; 
    public Sprite[] correctStoneSprites; 
    public Sprite[] incorrectStoneSprites; 
    public Sprite defaultSprite; 
    public float incorrectDisplayDuration = 1f; 

    public int currentIndex = 0; 

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
                    ChangeStonePlacementIndicator(true); 
                    currentIndex++; 
                    if (placedStoneTypes.Count >= requiredStoneCount)
                    {
                        break; 
                    }
                }
                else
                {   
                    inventory.RemoveStone(stoneType);
                    Debug.Log("This stone doesn't fit.");
                    StartCoroutine(DisplayIncorrectSprite()); 
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

    private void ChangeStonePlacementIndicator(bool correct)
    {
        if (stonePlacementIndicator != null)
        {
            SpriteRenderer spriteRenderer = stonePlacementIndicator.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                if (correct && currentIndex < correctStoneSprites.Length)
                {
                    spriteRenderer.sprite = correctStoneSprites[currentIndex];
                }
            }
        }
    }

    private IEnumerator DisplayIncorrectSprite()
    {
        if (stonePlacementIndicator != null)
        {
            SpriteRenderer spriteRenderer = stonePlacementIndicator.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                if (currentIndex < incorrectStoneSprites.Length)
                {
                    // Display incorrect sprite at the current index
                    spriteRenderer.sprite = incorrectStoneSprites[currentIndex];
                    yield return new WaitForSeconds(incorrectDisplayDuration);

                    // Revert to correct sprite or default sprite if no correct stones placed yet
                    if (currentIndex > 0 && currentIndex - 1 < correctStoneSprites.Length)
                    {
                        spriteRenderer.sprite = correctStoneSprites[currentIndex - 1];
                    }
                    else
                    {
                        spriteRenderer.sprite = defaultSprite;
                    }
                }
            }
        }
    }
}

