using System.Collections.Generic; // Add this namespace for List
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SceneInitializer : MonoBehaviour
{
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        Debug.Log("SceneInitializer: Initialize called");

        // Reassign the necessary components for QuestManager
        QuestManager questManager = QuestManager.Instance;

        if (questManager != null)
        {
            GameObject questWindowObj = FindInactiveObjectByName("QuestWindow");
            GameObject titleTextObj = FindInactiveObjectByName("TitleText");
            GameObject descriptionTextObj = FindInactiveObjectByName("DescriptionText");

            Debug.Log($"QuestWindow found: {questWindowObj != null}");
            Debug.Log($"TitleText found: {titleTextObj != null}");
            Debug.Log($"DescriptionText found: {descriptionTextObj != null}");

            questManager.questWindow = questWindowObj;
            questManager.titleText = titleTextObj?.GetComponent<TextMeshProUGUI>();
            questManager.descriptionText = descriptionTextObj?.GetComponent<TextMeshProUGUI>();

            if (questManager.questWindow == null) Debug.LogWarning("Quest Window reference is missing");
            if (questManager.titleText == null) Debug.LogWarning("Title Text reference is missing");
            if (questManager.descriptionText == null) Debug.LogWarning("Description Text reference is missing");
        }

        // Reassign the necessary components for WayPointManager
        WayPointManager wayPointManager = WayPointManager.Instance;

        if (wayPointManager != null)
        {
            wayPointManager.player = GameObject.FindWithTag("Player")?.transform;
            wayPointManager.mainCamera = Camera.main;
            wayPointManager.waypointImage = GameObject.Find("WaypointImage")?.GetComponent<Image>();

            Debug.Log($"Player found: {wayPointManager.player != null}");
            Debug.Log($"Main Camera found: {wayPointManager.mainCamera != null}");
            Debug.Log($"WaypointImage found: {wayPointManager.waypointImage != null}");

            if (wayPointManager.player == null) Debug.LogWarning("Player reference is missing");
            if (wayPointManager.mainCamera == null) Debug.LogWarning("Main Camera reference is missing");
            if (wayPointManager.waypointImage == null) Debug.LogWarning("Waypoint Image reference is missing");
        }
    }

    // Method to find inactive GameObjects
    private GameObject FindInactiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None && objs[i].name == name)
            {
                return objs[i].gameObject;
            }
        }
        return null;
    }
}
