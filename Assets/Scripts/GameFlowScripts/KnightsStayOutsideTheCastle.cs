using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightsStayOutsideTheCastle : MonoBehaviour
{
     public bool Triggered;


    void Start()
    {
        Triggered = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Triggered && other.CompareTag("Player"))
        {
        Triggered = true;
            NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
            GameObject[] defendGameObjects = GameObject.FindGameObjectsWithTag("DefendPoint");
            Transform[] DefendPoints = new Transform[defendGameObjects.Length];
            for (int i = 0; i < defendGameObjects.Length; i++)
            {
                DefendPoints[i] = defendGameObjects[i].transform;
            }

            for (int i = 0; i < knightBehaviours.Length && i < DefendPoints.Length; i++)
            {
                knightBehaviours[i].isFollowing = false;  // Set isFollowing to false
                knightBehaviours[i].GoToDestination(DefendPoints[i]);
            }
        }
    }

    
}
