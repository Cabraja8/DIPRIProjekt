using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger2 : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Quest quest; // Reference to the quest to be added to the queue
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
        if (quest != null)
        {
            QuestManager.Instance.AddQuest(quest); // Add the quest to the QuestManager's queue
            enabled = false; // Disable the script to prevent multiple triggers
        }
    }
}
