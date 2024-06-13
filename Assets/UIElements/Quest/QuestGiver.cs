using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest; // Reference to the quest to be given
    public Player player; // Reference to the player (if needed)

    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public void StartQuest()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        if (quest.waypoint != null)
        {
            WayPointManager.Instance.SetActiveWaypoint(quest.waypoint, quest); // Activate waypoint with quest reference
        }
    }

    public void ClearQuestWindow()
    {
        titleText.text = "";
        descriptionText.text = "";
        questWindow.SetActive(false);
    }
}
