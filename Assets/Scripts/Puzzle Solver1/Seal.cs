using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour, Interactable
{
    public bool Interacted;
    public List<StoneType> requiredStoneTypes;
    public int requiredStoneCount; 
    private List<StoneType> placedStoneTypes = new List<StoneType>();
    public GameObject stonePlacementIndicator; 
    public Sprite[] correctStoneSprites; 
    public Sprite[] incorrectStoneSprites; 
    public Sprite defaultSprite; 
    public float incorrectDisplayDuration = 1f; 
    public int currentIndex = 0; 
    public GameObject door;
    public Sprite OpenedDoor;
    public GameObject Crown;


    void Start()
    {
        Crown.SetActive(false);
        
    }

    public void Interact()
    {
        Interacted = true;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            List<StoneType> stonesToRemove = new List<StoneType>();
            List<StoneType> incorrectStones = new List<StoneType>();

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
                    incorrectStones.Add(stoneType);
                }
            }

            foreach (StoneType stoneType in stonesToRemove)
            {
                inventory.RemoveStone(stoneType);
            }

            foreach (StoneType stoneType in incorrectStones)
            {
                inventory.RemoveStone(stoneType);
                Debug.Log("This stone doesn't fit.");
                StartCoroutine(DisplayIncorrectSprite()); 
            }

            if (CheckIfPuzzleSolved())
            {
                
                Invoke("OpenSeal",3f);
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
        door.GetComponent<SpriteRenderer>().sprite = OpenedDoor;
        Crown.SetActive(true);
        RemoveStones();
        RemoveInteractable();
    
    }
    private void RemoveInteractable(){
        Destroy(this);
    }

    public void ResetInteraction()
    {
        Interacted = false;
    }
    private void RemoveStones()
    {
        Stone[] stones = FindObjectsOfType<Stone>();
        foreach (Stone stone in stones)
        {
            stone.enabled = false;
            CircleCollider2D collider = stone.GetComponent<CircleCollider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
        }
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
                    
                    spriteRenderer.sprite = incorrectStoneSprites[currentIndex];
                    yield return new WaitForSeconds(incorrectDisplayDuration);

                
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


