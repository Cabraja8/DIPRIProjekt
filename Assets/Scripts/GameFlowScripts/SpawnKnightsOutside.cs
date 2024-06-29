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
        if (!PlayerCollided)
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
        FollowPlayerKnights();
    }

    public void FollowPlayerKnights()
    {
        NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
        foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours)
        {
            knightBehaviour.Target = null;
            knightBehaviour.isFollowing = true;
        }
    }
}

