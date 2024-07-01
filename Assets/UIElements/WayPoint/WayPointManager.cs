using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPointManager : MonoBehaviour
{
    public static WayPointManager Instance;
    public List<Transform> waypoints = new List<Transform>();
    public Image waypointImage;
    public Camera mainCamera;
    public Transform player;
    private int currentWaypointIndex = 0;
    private bool waypointsCompleted = false;
    public Quest activeQuest;

    public float proximityThreshold = 5.0f;
    public float edgeBuffer = 50.0f;

    private Dictionary<string, Transform> waypointReferences = new Dictionary<string, Transform>();

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
    private void Update()
    {
        if (waypointsCompleted || waypoints.Count == 0 || waypointImage == null || player == null || mainCamera == null)
            return;

        if (currentWaypointIndex >= waypoints.Count || waypoints[currentWaypointIndex] == null)
        {
            waypointsCompleted = true;
            if (waypointImage != null) waypointImage.enabled = false;
            Debug.Log("All waypoints visited or current waypoint is null!");
            return;
        }

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
        if (currentWaypointIndex >= waypoints.Count || reachedWaypoint == null)
        {
            waypointsCompleted = true;
            if (waypointImage != null) waypointImage.enabled = false;
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
        if (waypoint == null || waypointImage == null || mainCamera == null)
        {
            if (waypointImage != null) waypointImage.enabled = false;
            return;
        }

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
        if (waypointImage != null) waypointImage.enabled = true;
        UpdateWaypointImagePosition(waypoints[currentWaypointIndex]);
    }

    public void RegisterWaypoint(string id, Transform waypoint)
    {
        if (!waypointReferences.ContainsKey(id))
        {
            waypointReferences.Add(id, waypoint);
        }
    }

    public Transform GetWaypoint(string id)
    {
        if (waypointReferences.ContainsKey(id))
        {
            return waypointReferences[id];
        }
        return null;
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
