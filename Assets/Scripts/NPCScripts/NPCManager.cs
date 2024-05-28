using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public string homePointTag = "HomePoint";  // Tag for home points
    public GameObject[] npcPrefabs;  // Array of NPC prefabs

    private List<GameObject> spawnedNPCs = new List<GameObject>();  // List to keep track of spawned NPCs
    private bool hasAnyNPCReachedHome = false; // Flag to track if any NPC has reached a home point

    void Start()
    {
        // Example usage
        // FirstStage();
        // Invoke("SecondStage", 10f);
    }

    public void FirstStage()
    {
        // Find all home points by tag
        GameObject[] homePointObjects = GameObject.FindGameObjectsWithTag(homePointTag);
        Transform[] homePoints = new Transform[homePointObjects.Length];
        for (int i = 0; i < homePointObjects.Length; i++)
        {
            homePoints[i] = homePointObjects[i].transform;
        }

        // Spawn NPCs and enable patrol or idle behavior for each of them
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
            else
            {
                EnableIdle(npcInstance);
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

    void EnableIdle(GameObject npc)
    {
        NPCIdle idleComponent = npc.GetComponent<NPCIdle>();
        if (idleComponent != null)
        {
            idleComponent.enabled = true;
        }
        else
        {
            Debug.LogWarning($"NPCIdle component not found on {npc.name}");
        }
    }

    public void SecondStage()
    {   
        Debug.Log("Second stage");
        // Find all home points by tag
        GameObject[] homePointObjects = GameObject.FindGameObjectsWithTag(homePointTag);
        List<Transform> homePointList = new List<Transform>();
        foreach (GameObject obj in homePointObjects)
        {
            homePointList.Add(obj.transform);
        }

        // Make all NPCs go to random home points and disappear
        foreach (GameObject npc in spawnedNPCs)
        {
            if (homePointList.Count == 0) break;

            UnityEngine.AI.NavMeshAgent agent = npc.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agent != null)
            {
                // Pick a random home point and set it as the destination
                int randomIndex = Random.Range(0, homePointList.Count);
                Transform homePoint = homePointList[randomIndex];
                homePointList.RemoveAt(randomIndex);

                agent.SetDestination(homePoint.position);
                StartCoroutine(WaitAndDeactivate(agent, npc));
            }
        }
    }

  private IEnumerator WaitAndDeactivate(UnityEngine.AI.NavMeshAgent agent, GameObject npc)
{
    // Wait until the agent reaches the destination or the agent becomes inactive
    while (agent.isActiveAndEnabled && (agent.pathPending || agent.remainingDistance > 0.1f))
    {
        yield return null;
    }

    // Deactivate the NPC that reached its destination
    npc.SetActive(false);

    // Check if all NPCs have reached home
    bool allNPCsReachedHome = true;
    foreach (GameObject spawnedNpc in spawnedNPCs)
    {
        if (spawnedNpc.activeSelf) // Check if NPC is still active
        {
            allNPCsReachedHome = false;
            break;
        }
    }

    // If all NPCs have reached home, do any further actions here
    if (allNPCsReachedHome)
    {
        // Perform any actions after all NPCs have reached home
    }
}
}
