using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest; // Reference to the quest to be given

    public void StartQuest()
    {
        QuestManager.Instance.AddQuest(quest);
    }

    public void AcceptQuest()
    {
        QuestManager.Instance.AcceptCurrentQuest();
    }

    private void Start()
    {
        quest.order = 1; // Assign the order value, e.g., 1 for the first quest
    }
}
