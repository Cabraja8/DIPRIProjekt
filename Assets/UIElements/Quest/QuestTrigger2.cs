using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger2 : MonoBehaviour
{
    public QuestGiver questGiver; // Reference to the QuestGiver

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerQuest();
        }
    }

    public void TriggerQuest()
    {
        questGiver.StartQuest(); // Start the quest when the player reaches the object
    }
}
