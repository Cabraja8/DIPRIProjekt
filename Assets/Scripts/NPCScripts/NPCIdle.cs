using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdle : NPC
{
    // Start is called before the first frame update
    void Start()
    {

        // Find all GameObjects with the tag "IdlePoint"
        GameObject[] idlePointObjects = GameObject.FindGameObjectsWithTag("IdlePoint");
        if (idlePointObjects.Length > 0)
        {
            // Choose a random IdlePoint
            int randomIndex = Random.Range(0, idlePointObjects.Length);
            GameObject idlePointObject = idlePointObjects[randomIndex];

            // Set the agent's destination to the position of the selected IdlePoint
            agent.SetDestination(idlePointObject.transform.position);
        }
        else
        {
            Debug.LogWarning("No GameObjects found with tag 'IdlePoint'");
        }
    }

}
