using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SpawnEnemiesInCastle : MonoBehaviour
{   
    public GameObject enemyPrefab; 
    public Transform[] SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        // Ensure EnemyCounter does not exceed the number of available spawn points
        int enemiesToSpawn = Mathf.Min(SpawnPoints.Length, SpawnPoints.Length);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Transform spawnPoint = SpawnPoints[i];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

