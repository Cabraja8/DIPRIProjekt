using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public Transform[] homePoints;  // Array of home points for the NPCs
    public GameObject[] npcPrefabs;  // Array of NPC prefabs

    private List<GameObject> spawnedNPCs = new List<GameObject>();  // List to keep track of spawned NPCs

    void Start()
    {
        // Example usage
        FirstStage();
    }

    public void FirstStage()
    {
        // Spawn NPCs and enable patrol behavior for some of them
        foreach (Transform homePoint in homePoints)
        {
            GameObject npcPrefab = npcPrefabs[Random.Range(0, npcPrefabs.Length)];
            GameObject npcInstance = Instantiate(npcPrefab, homePoint.position, homePoint.rotation);
            spawnedNPCs.Add(npcInstance);

            // Randomly decide if this NPC should patrol or idle
            if (Random.value > 0.5f)
            {
                EnablePatrol(npcInstance);
            }
        }
    }

    void EnablePatrol(GameObject npc)
    {
        NPCPatrol patrolComponent = npc.GetComponent<NPCPatrol>();
        if (patrolComponent != null)
        {
            patrolComponent.enabled = true;
        }
        else
        {
            Debug.LogWarning($"NPCPatrol component not found on {npc.name}");
        }
    }

    public void SecondStage()
    {
        // Make all NPCs go to their home points and disappear
       
    }

   
}
