using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    private Queue<Quest> questQueue = new Queue<Quest>();
    private Quest currentQuest;

    // UI elements
    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the QuestManager across scenes if needed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddQuest(Quest newQuest)
    {
        questQueue.Enqueue(newQuest);
        if (currentQuest == null) // If no quest is active, start the next one
        {
            StartNextQuest();
        }
    }

    public void AcceptCurrentQuest()
    {
        if (currentQuest != null)
        {
            questWindow.SetActive(false);
            currentQuest.isActive = true;
            if (currentQuest.waypoint != null)
            {
                WayPointManager.Instance.SetActiveWaypoint(currentQuest.waypoint, currentQuest); // Activate waypoint with quest reference
            }
            currentQuest = null;
            StartNextQuest();
        }
    }

    private void StartNextQuest()
    {
        if (questQueue.Count > 0)
        {
            currentQuest = questQueue.Dequeue();
            ShowQuest(currentQuest);
        }
    }

    public void CompleteCurrentQuest(Transform reachedWaypoint)
    {
        if (currentQuest != null && currentQuest.CheckIfCompleted(reachedWaypoint))
        {
            currentQuest = null;
            StartNextQuest(); // Start the next quest in the queue, if any
        }
    }

    private void ShowQuest(Quest quest)
    {
        // Update the UI elements to display the quest
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        questWindow.SetActive(true);
        Debug.Log("New Quest Started: " + quest.title);
    }
}
