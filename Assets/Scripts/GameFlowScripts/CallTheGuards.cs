using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTheGuards : MonoBehaviour, Interactable
{      
    public GameObject Guards;
    public GameObject[] spawnPoints; 
    public Animator anim;

    private bool IsRinged;


    void Start()
    {
        anim = GetComponent<Animator>();
    }



    public void Interact(){
        // Play Audio treba dodat ali kasnije
        IsRinged = true;
        anim.SetTrigger("Ring");
        Invoke("SpawnGuards",1f);
    }

    public bool CanInteract(){
        return !IsRinged;
    }
    
  

 
    public void SpawnGuards(){

        Debug.Log("Spawning guards");
        //   if (spawnPoints.Length == 0)
        // {
        //     Debug.LogWarning("No spawn points defined.");
        //     return;
        // }

        // GameObject chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // Instantiate(Guards, chosenSpawnPoint.transform.position, Quaternion.identity);
    }


}
