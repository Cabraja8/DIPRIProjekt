using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public RectTransform canvas; // Assign the GameCanvas here
    public GameObject waypointIconPrefab; // Assign the WaypointIconPrefab here
    public Camera mainCamera; // Assign the main camera here

    private List<WayPoint> waypoints = new List<WayPoint>();

    public void CreateWaypoint(Transform target)
    {
        if (canvas == null || waypointIconPrefab == null || mainCamera == null)
        {
            Debug.LogError("WaypointManager: Missing references. Please assign all references in the Inspector.");
            return;
        }

        GameObject icon = Instantiate(waypointIconPrefab, canvas);
        WayPoint waypoint = icon.AddComponent<WayPoint>();
        waypoint.target = target;
        waypoint.waypointIcon = icon.GetComponent<RectTransform>();
        waypoint.mainCamera = mainCamera;
        waypoint.canvas = canvas.GetComponent<Canvas>();
        waypoints.Add(waypoint);
    }

    public void RemoveWaypoint(Transform target)
    {
        WayPoint waypoint = waypoints.Find(wp => wp.target == target);
        if (waypoint != null)
        {
            Destroy(waypoint.waypointIcon.gameObject);
            waypoints.Remove(waypoint);
        }
    }
}
