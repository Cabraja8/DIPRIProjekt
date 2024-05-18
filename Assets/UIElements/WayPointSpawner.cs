using UnityEngine;

public class WayPointSpawner : MonoBehaviour
{
    public WayPointManager waypointManager;

    void Start()
    {
        if (waypointManager == null)
        {
            Debug.LogError("WaypointSpawner: WaypointManager is not assigned. Please assign it in the Inspector.");
            return;
        }

        // Example: Create a waypoint for a predefined target at runtime
        Transform target = new GameObject("Target").transform;
        target.position = new Vector3(Random.Range(100, -50), 0, Random.Range(100, -50));
        waypointManager.CreateWaypoint(target);
    }

    void Update()
    {
        if (waypointManager == null)
        {
            return;
        }

        // Example: Create a waypoint for a new target at runtime
        if (Input.GetKeyDown(KeyCode.M))
        {
            Transform newTarget = new GameObject("Target").transform;
            newTarget.position = new Vector3(Random.Range(100, -50), 0, Random.Range(100, -50));
            waypointManager.CreateWaypoint(newTarget);
        }

        // Example: Remove a waypoint for a target at runtime
        if (Input.GetKeyDown(KeyCode.R))
        {
            // This example assumes you have a reference to the target you want to remove
            // You need to implement logic to track and remove specific targets
        }
    }
}
