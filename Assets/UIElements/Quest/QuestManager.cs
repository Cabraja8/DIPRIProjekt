using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    private List<Quest> questQueue = new List<Quest>();
    private Quest currentQuest;
    private Quest lastAcceptedQuest; 
    private List<Quest> completedQuests = new List<Quest>();

    public int expectedQuestCount;
    public int currentQuestOrder = 0;
    //UI
    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public delegate void AllQuestsCompleted();
    public static event AllQuestsCompleted OnAllQuestsCompleted;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Other methods...
    public void AddQuest(Quest newQuest)
    {
        questQueue.Add(newQuest);
        questQueue.Sort((q1, q2) => q1.order.CompareTo(q2.order)); // Sort quests by order
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
            lastAcceptedQuest = currentQuest; // Track the last accepted quest
            if (currentQuest.waypoint != null)
            {
                WayPointManager.Instance.SetActiveWaypoint(currentQuest.waypoint, currentQuest); // Activate waypoint with quest reference
            }
            currentQuestOrder = currentQuest.order;
            currentQuest = null;
            StartNextQuest();
        }
    }

    private void StartNextQuest()
    {
        if (questQueue.Count > 0)
        {
            currentQuest = questQueue[0];
            questQueue.RemoveAt(0);
            ShowQuest(currentQuest);
        }
        else if (completedQuests.Count == expectedQuestCount) // Check if all expected quests are completed
        {
            OnAllQuestsCompleted?.Invoke();
            // Invoke the event
        }
    }

    public void CompleteCurrentQuest(Transform reachedWaypoint)
    {
        if (currentQuest != null && currentQuest.CheckIfCompleted(reachedWaypoint))
        {
            completedQuests.Add(currentQuest);
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

    // Method to show the current quest details
    public void ShowCurrentQuest()
    {
        if (lastAcceptedQuest != null && lastAcceptedQuest.isActive)
        {
            // Show the last accepted quest
            titleText.text = "Last Accepted Quest: " + lastAcceptedQuest.title;
            descriptionText.text = lastAcceptedQuest.description;
            questWindow.SetActive(true);
        }
        else if (currentQuest != null)
        {
            // Show the current quest that can be accepted
            titleText.text = "Next Quest: " + currentQuest.title;
            descriptionText.text = currentQuest.description;
            questWindow.SetActive(true);
        }
        else if (questQueue.Count > 0)
        {
            // Show the next quest in the queue
            Quest nextQuest = questQueue[0];
            titleText.text = "Next Quest: " + nextQuest.title;
            descriptionText.text = nextQuest.description;
            questWindow.SetActive(true);
        }
        else
        {
            titleText.text = "No Active Quest";
            descriptionText.text = "";
            questWindow.SetActive(true);
        }
    }

    // Method to be called by the button
    public void OnShowCurrentQuestButtonPressed()
    {
        ShowCurrentQuest();
    }

    // Method to cancel the current quest
    public void CancelCurrentQuest()
    {
        questWindow.SetActive(false);
        Debug.Log("Current quest UI was closed");
    }

    // Method to be called by the cancel button
    public void OnCancelQuestButtonPressed()
    {
        CancelCurrentQuest();
    }
}
