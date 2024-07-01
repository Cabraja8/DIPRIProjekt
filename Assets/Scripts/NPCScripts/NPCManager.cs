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
            }else{
                GoToIdlePoints(npcInstance);
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
        Debug.Log("Second Stage");
        for (int i = 0; i < spawnedNPCs.Count; i++)
        {
            GameObject npc = spawnedNPCs[i];
            NPCIdle idleComponent = npc.GetComponent<NPCIdle>();
            if (idleComponent != null)
            {
                idleComponent.enabled = false;
            }

            NPCPatrol patrolComponent = npc.GetComponent<NPCPatrol>();
            if (patrolComponent != null)
            {
                patrolComponent.enabled = false;
            }

            if (i < homePoints.Length)
            {
                MoveToHomePointAndDisappear(npc, homePoints[i]);
            }
            else
            {
                Debug.LogWarning($"No home point assigned for NPC {npc.name}");
                Destroy(npc);
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
            
            Destroy(npc);
        }
    }

    public void GoToIdlePoints(GameObject npc){
        NPCIdle idle = npc.GetComponent<NPCIdle>();
          if (idle != null)
        {
            idle.enabled = true;
        }
        else
        {
            Debug.LogWarning($"NPCPatrol component not found on {npc.name}");
        }

    }
}
