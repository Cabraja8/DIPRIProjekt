using UnityEngine;

public class RegisterWaypoint : MonoBehaviour
{
    public string waypointID;

    private void Start()
    {
        WayPointManager.Instance.RegisterWaypoint(waypointID, transform);
    }
}
