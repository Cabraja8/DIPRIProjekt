using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    private Vector3 spawnPointPosition; // Position of the spawn point

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

    // Sets the spawn point position
    public void SetSpawnPoint(Vector3 spawnPoint)
    {
        spawnPointPosition = spawnPoint;
    }

    // Retrieves the spawn point position
    public Vector3 GetSpawnPoint()
    {
        return spawnPointPosition;
    }

    // Clears the spawn point position
    public void ClearSpawnPoint()
    {
        spawnPointPosition = Vector3.zero; // Or any default value you prefer
    }

    // Example function to spawn player at the stored spawn point
    public void SpawnPlayerAtSpawnPoint()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = spawnPointPosition;
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
        }
    }
}









