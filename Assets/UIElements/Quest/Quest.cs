using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string title;
    public string description;
    public QuestSystem goal; // Represents the goal type and specifics
    public Transform waypoint; // Represents the location to reach for the quest

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " was completed");
        QuestManager.Instance.CompleteCurrentQuest(waypoint); ////novoIvana
    }

    public bool CheckIfCompleted(Transform reachedWaypoint)
    {
        if (isActive && waypoint == reachedWaypoint)
        {
            Complete();
            return true;
        }
        return false;
    }
}
