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

    void Start()
    {   	
        CallTriggerGuards.SetActive(false);
        anim = GetComponent<Animator>();
    }

    public void Interact(){
        // Play Audio treba dodat ali kasnije
        IsRinged = true;
        anim.SetTrigger("Ring");
        isSpawning = true;
        InvokeRepeating("SpawnGuard", 0f, 1f); 
    }

    public bool CanInteract(){
        return !IsRinged;
    }
    
    public void SpawnGuard(){
        Debug.Log("Spawning a guard");

        if (guardsSpawned >= 6 || !isSpawning)
        {

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