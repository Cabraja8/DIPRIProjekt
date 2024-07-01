using UnityEngine;

public class SpawnEnemiesInCamp : MonoBehaviour
{
    public bool Triggered;
    public Transform[] SpawnPointsForEnemies; 
    public Enemy[] enemies; 


  
    void Start()
    {
        Triggered = false;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!Triggered && other.CompareTag("Player"))
        {
            Triggered = true;
            SpawnEnemies();
        }
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < SpawnPointsForEnemies.Length; i++)
        {
            foreach (Enemy enemyPrefab in enemies)
            {
                Transform spawnPoint = SpawnPointsForEnemies[i];
                Enemy enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                enemyInstance.CanDetectFromFar = false;
            }
        }
    }
}


