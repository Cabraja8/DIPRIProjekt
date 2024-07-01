using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoreKnights : MonoBehaviour
{
    public GameObject Guards;
    public GameObject[] spawnPoints;
    private int guardsSpawned = 0;
    private bool isSpawning = false;

    public void SpawnKnights()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating("SpawnGuard", 0.2f, 0.5f);
        }
    }

    public void SpawnGuard()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points defined.");
            CancelInvoke("SpawnGuard");
            return;
        }

        if (guardsSpawned >= 6 || !isSpawning)
        {
            CancelInvoke("SpawnGuard");
            isSpawning = false;
            return;
        }

        GameObject chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(Guards, chosenSpawnPoint.transform.position, Quaternion.identity);
        guardsSpawned++;
        MakeKnightsNotAttack(); // Call the method to make knights not attack after spawning
    }

    public void MakeKnightsNotAttack()
    {
        NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
        foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours)
        {
            Debug.Log("Making knights not attack");
            knightBehaviour.CanDetectFromFar = false;
            // Additional logic to make knights not attack
        }
    }
}

