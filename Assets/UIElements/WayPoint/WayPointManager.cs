using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPointManager : MonoBehaviour
{
    public static WayPointManager Instance; // Singleton instance
    public List<Transform> waypoints;
    public Image waypointImage;
    public Camera mainCamera;
    public Transform player;
    private int currentWaypointIndex = 0;
    private bool waypointsCompleted = false;
    public Quest activeQuest; // Reference to the active quest

    public float proximityThreshold = 5.0f;
    public float edgeBuffer = 50.0f;

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

    private void Update()
    {
        if (waypointsCompleted || waypoints.Count == 0)
            return;

        float distance = Vector3.Distance(player.position, waypoints[currentWaypointIndex].position);

        if (distance <= proximityThreshold)
        {
            ReachWaypoint();
        }

        UpdateWaypointImagePosition(waypoints[currentWaypointIndex]);
    }

    private void ReachWaypoint()
    {
        Transform reachedWaypoint = waypoints[currentWaypointIndex];
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Count)
        {
            waypointsCompleted = true;
            waypointImage.enabled = false;
            Debug.Log("All waypoints visited!");
        }

        if (activeQuest != null && activeQuest.CheckIfCompleted(reachedWaypoint))
        {
            QuestManager.Instance.CompleteCurrentQuest(reachedWaypoint); // Notify QuestManager of quest completion
            activeQuest = null; // Clear the active quest once completed
        }

        if (!waypointsCompleted)
        {
            UpdateWaypointImagePosition(waypoints[currentWaypointIndex]);
        }
    }

    private void UpdateWaypointImagePosition(Transform waypoint)
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(waypoint.position);
        bool isOffScreen = screenPosition.z < 0 || screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height;

        if (isOffScreen)
        {
            screenPosition = ClampToScreenEdge(screenPosition);
        }

        waypointImage.transform.position = screenPosition;
    }

    private Vector3 ClampToScreenEdge(Vector3 screenPosition)
    {
        if (screenPosition.z < 0)
        {
            screenPosition *= -1;
        }

        screenPosition.x = Mathf.Clamp(screenPosition.x, edgeBuffer, Screen.width - edgeBuffer);
        screenPosition.y = Mathf.Clamp(screenPosition.y, edgeBuffer, Screen.height - edgeBuffer);

        return screenPosition;
    }

    public void SetActiveWaypoint(Transform waypoint, Quest quest)
    {
        waypoints.Clear();
        waypoints.Add(waypoint);
        currentWaypointIndex = 0;
        waypointsCompleted = false;
        activeQuest = quest;
        waypointImage.enabled = true;
        UpdateWaypointImagePosition(waypoints[currentWaypointIndex]);
    }

    private void OnDrawGizmos()
    {
        if (waypoints == null)
            return;

        Gizmos.color = Color.red;
        for (int i = 0; i < waypoints.Count; i++)
        {
            if (waypoints[i] != null)
            {
                if (i + 1 < waypoints.Count && waypoints[i + 1] != null)
                {
                    Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
                }
                Gizmos.DrawSphere(waypoints[i].position, 0.3f);
            }
        }
    }
}
