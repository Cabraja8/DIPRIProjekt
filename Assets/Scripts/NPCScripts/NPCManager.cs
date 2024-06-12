using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public Transform[] homePoints;  
    public GameObject[] npcPrefabs;  

    private List<GameObject> spawnedNPCs = new List<GameObject>();  

    void Start()
    {
        FirstStage();
        Invoke("SecondStage",15f);
    }

    public void FirstStage()
    {
        Debug.Log("FirstStage");
        foreach (Transform homePoint in homePoints)
        {
            GameObject npcPrefab = npcPrefabs[Random.Range(0, npcPrefabs.Length)];
            GameObject npcInstance = Instantiate(npcPrefab, homePoint.position, homePoint.rotation);
            spawnedNPCs.Add(npcInstance);

            
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
       
        for (int i = 0; i < spawnedNPCs.Count; i++)
        {
            GameObject npc = spawnedNPCs[i];
            if (i < homePoints.Length)
            {
                MoveToHomePointAndDisappear(npc, homePoints[i]);
            }
        }
    }

    void MoveToHomePointAndDisappear(GameObject npc, Transform homePoint)
    {
        
        NPC npcController = npc.GetComponent<NPC>();
        if (npcController != null)
        {
            npcController.MoveTo(homePoint.position, () => {
                Destroy(npc);
            });
        }
        else
        {
            Debug.LogWarning($"NPCController component not found on {npc.name}");
            Destroy(npc);
        }
    }
}
