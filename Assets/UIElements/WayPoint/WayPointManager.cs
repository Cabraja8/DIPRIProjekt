using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPointManager : MonoBehaviour
{
    public List<Transform> waypoints;
    public Image waypointImage; // UI Image to indicate the waypoint
    public Camera mainCamera; // Main camera to convert world position to screen position
    public Transform player; // Reference to the player transform
    private int currentWaypointIndex = 0;
    private bool waypointsCompleted = false; // Flag to indicate all waypoints are visited

    public float proximityThreshold = 5.0f; // Adjusted threshold to match observed distances
    public float edgeBuffer = 50f; // Buffer to keep the waypoint image inside the screen edges

    private void Start()
    {
        if (waypoints.Count == 0)
            return;

        UpdateWaypointImagePosition(waypoints[currentWaypointIndex]);
    }

    private void Update()
    {
        if (waypoints.Count == 0 || waypointsCompleted)
            return;

        Transform currentWaypoint = waypoints[currentWaypointIndex];
        float distanceToWaypoint = Vector3.Distance(player.position, currentWaypoint.position);

        UpdateWaypointImagePosition(currentWaypoint);

        if (distanceToWaypoint < proximityThreshold)
        {
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Count)
        {
            waypointsCompleted = true;
            waypointImage.enabled = false; // Hide the waypoint image when done
            Debug.Log("All waypoints visited!");
            return;
        }

        UpdateWaypointImagePosition(waypoints[currentWaypointIndex]);
    }

    private void UpdateWaypointImagePosition(Transform waypoint)
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(waypoint.position);

        // Check if the waypoint is off-screen
        bool isOffScreen = screenPosition.z < 0 || screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height;

        if (isOffScreen)
        {
            // Keep the waypoint image at the edge of the screen with a buffer
            screenPosition = ClampToScreenEdge(screenPosition);
        }

        waypointImage.transform.position = screenPosition;
    }

    private Vector3 ClampToScreenEdge(Vector3 screenPosition)
    {
        // Flip screen position if waypoint is behind the camera
        if (screenPosition.z < 0)
        {
            screenPosition *= -1;
        }

        screenPosition.x = Mathf.Clamp(screenPosition.x, edgeBuffer, Screen.width - edgeBuffer);
        screenPosition.y = Mathf.Clamp(screenPosition.y, edgeBuffer, Screen.height - edgeBuffer);

        return screenPosition;
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
