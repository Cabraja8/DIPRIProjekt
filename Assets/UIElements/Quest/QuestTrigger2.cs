using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger2 : MonoBehaviour
{
    public QuestGiver questGiver; // Reference to the QuestGiver
    public Transform player; // Reference to the player's transform
    public float proximityThreshold = 5.0f; // Distance threshold for triggering the quest

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= proximityThreshold)
        {
            TriggerQuest();
        }
    }

    public void TriggerQuest()
    {
        if (questGiver != null)
        {
            questGiver.StartQuest();
            enabled = false; // Disable the script to prevent multiple triggers
        }
    }
}
