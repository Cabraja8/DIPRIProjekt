using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesInCamp : MonoBehaviour
{   
    public bool Triggered;
    public Transform SpawnPointForEnemies;
    public Enemy[] enemies; // Array to hold the enemy prefabs
    public int numberOfEnemiesToSpawn = 6; // Number of enemies to spawn

    // Start is called before the first frame update
    void Start()
    {
        Triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (!Triggered){
            Triggered = true;
            SpawnEnemies();
        }
    }

     public void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            foreach (Enemy enemyPrefab in enemies)
            {
                Enemy enemyInstance = Instantiate(enemyPrefab, SpawnPointForEnemies.position, SpawnPointForEnemies.rotation);
                enemyInstance.CanDetectFromFar = false;
            }
        }
    }
}

