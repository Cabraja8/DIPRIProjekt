using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnightsOutside : MonoBehaviour
{
    public GameObject Knights;
    public Transform[] SpawnPosition;
    public bool PlayerCollided;

    void Start()
    {
        PlayerCollided = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !PlayerCollided)
        {
            PlayerCollided = true;
            SpawnKnightsOnPoint();
        }
    }

    public void SpawnKnightsOnPoint()
    {
        foreach (Transform spawnPoint in SpawnPosition)
        {
            Instantiate(Knights, spawnPoint.position, spawnPoint.rotation);
        }
        Invoke("FollowPlayerKnights",1f);
        
    }

    public void FollowPlayerKnights()
    {   
        
        NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
        foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours)
        {
            knightBehaviour.Target = null;
            knightBehaviour.FollowPlayer();
            knightBehaviour.CanDetectFromFar = false;
        }
        Invoke("MakeKnightsFightInTheWave",5f);
    }

    public void MakeKnightsFightInTheWave(){
         NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
        foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours)
        {
            
            knightBehaviour.isFollowing=false;
            knightBehaviour.CanDetectFromFar = true;
        }
    }
}

