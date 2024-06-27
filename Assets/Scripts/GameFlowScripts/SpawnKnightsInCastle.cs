using UnityEngine;

public class SpawnKnightsInCastle : MonoBehaviour
{
    public GameObject knightPrefab; // Reference to the knight prefab
    public Transform[] SpawnPoints; // Array of spawn points

    // Start is called before the first frame update
    void Start()
    {
        SpawnKnights();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnKnights()
    {
        // Ensure KnightCounter does not exceed the number of available spawn points
        int knightsToSpawn = Mathf.Min(SpawnPoints.Length, SpawnPoints.Length);

        for (int i = 0; i < knightsToSpawn; i++)
        {
            Transform spawnPoint = SpawnPoints[i];
            Instantiate(knightPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

