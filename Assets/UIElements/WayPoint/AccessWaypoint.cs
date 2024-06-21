using UnityEngine;

public class AccessWaypoint : MonoBehaviour
{
    public string waypointID;

    private void Start()
    {
        Transform waypoint = WayPointManager.Instance.GetWaypoint(waypointID);
        if (waypoint != null)
        {
            WayPointManager.Instance.SetActiveWaypoint(waypoint, null); // Pass the quest if needed
        }
        else
        {
            Debug.LogWarning("Waypoint not found for ID: " + waypointID);
        }
    }
}
