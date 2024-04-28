using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTheGuards : MonoBehaviour, Interactable
{      
    public GameObject Guards;
    public GameObject[] spawnPoints; 
    public Animator anim;

    private bool IsRinged;
    private int guardsSpawned = 0;
    private bool isSpawning = false;

    public GameObject CallTriggerGuards;

    public GameObject door;
    
    public Sprite closed_door;
    public Sprite opened_door;

     SpriteRenderer doorSpriteRenderer;
    void Start()
    {   	
        CallTriggerGuards.SetActive(false);
        anim = GetComponent<Animator>();
        doorSpriteRenderer = door.GetComponent<SpriteRenderer>();
        
    }

    public void Interact(){
        // Play Audio treba dodat ali kasnije
        IsRinged = true;
        anim.SetTrigger("Ring");
        isSpawning = true;
        Invoke("OpenDoor",1f);
        InvokeRepeating("SpawnGuard", 1f, 2f); 
        
    }

    private void OpenDoor(){
    

    if (doorSpriteRenderer != null)
    {
        
        doorSpriteRenderer.sprite = opened_door;
    }
    }
    public bool CanInteract(){
        return !IsRinged;
    }
    
    public void SpawnGuard(){
    
        Debug.Log("Spawning a guard");

        if (guardsSpawned >= 6 || !isSpawning)
        {   
            if (doorSpriteRenderer != null)
    {
        
        doorSpriteRenderer.sprite = closed_door;
    }

            CancelInvoke("SpawnGuard");
            Invoke("EnableTrigger", 3f);
            return;
        }
        

        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points defined.");
            return;
        }

        GameObject chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
   
        Instantiate(Guards, chosenSpawnPoint.transform.position, Quaternion.identity);
        guardsSpawned++;
    }

    public void EnableTrigger(){
        CallTriggerGuards.SetActive(true);
    }
}