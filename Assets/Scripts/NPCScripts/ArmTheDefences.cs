using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ArmTheDefences : MonoBehaviour
{       

    public Transform[] defensePoints;

/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
/// </summary>
void Start()
{
     if (defensePoints.Length != 4)
        {
            Debug.LogError("Please assign exactly 4 defense points in the inspector.");
        }
}
  public void SetTheGuardsToDefend()
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Knight");

        if (guards.Length == 0)
        {
            Debug.LogWarning("No guards found with the tag 'Guard'.");
            return;
        }

        for (int i = 0; i < guards.Length; i++)
        {
            int pointIndex = i % defensePoints.Length;  // Use modulo to cycle through the points
            NavMeshAgent navMeshAgent = guards[i].GetComponent<NavMeshAgent>();

            if (navMeshAgent != null)
            {
                navMeshAgent.SetDestination(defensePoints[pointIndex].position);
            }
            else
            {
                Debug.LogError("NavMeshAgent component missing on guard: " + guards[i].name);
            }
        }
    }










}
