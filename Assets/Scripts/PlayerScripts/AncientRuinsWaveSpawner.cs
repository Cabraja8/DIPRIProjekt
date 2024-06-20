using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientRuinsWaveSpawner : MonoBehaviour
{
       [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    private bool finishedSpawning;

    public Wave[] waves;

    public Transform[] spawnPoints;
    public float timeBetweenWaves;


    public Wave currentWave;
    public int currentWaveIndex;

    public Transform player;
    public GameObject InvisibleBorder;


    private void Start()
    {   
        InvisibleBorder.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    
    }

    public void StartSpawning(){
        Debug.Log("Spawning");
        InvisibleBorder.SetActive(true);
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index)
    {

        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }
    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];
        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }
            else
            {
                Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
                Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
                if (i == currentWave.count - 1)
                {
                    finishedSpawning = true;
                }
                else
                {
                    finishedSpawning = false;
                }
                yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
            }
        }

    }

    private void Update()
    {

        if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpawning = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                // End of waves
                Debug.Log("End of wave");
               InvisibleBorder.SetActive(false);
            }
        }
    }

  


}
