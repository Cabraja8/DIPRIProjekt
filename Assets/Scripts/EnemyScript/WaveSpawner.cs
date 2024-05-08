using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
        public class Wave {
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

    public SceneTransfer sceneTransfer;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        InvisibleBorder.SetActive(false);
    }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
        InvisibleBorder.SetActive(true);
    }

    IEnumerator StartNextWave( int index){

        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }
    IEnumerator SpawnWave(int index){
        currentWave = waves[index];
        for(int i =0; i<currentWave.count;i++){
            if(player==null){
                yield break;
            }else{
                Enemy randomEnemy=currentWave.enemies[Random.Range(0,currentWave.enemies.Length)];
                Transform randomSpot = spawnPoints[Random.Range(0,spawnPoints.Length)];
                Instantiate(randomEnemy,randomSpot.position,randomSpot.rotation);
                Transform closestTarget = FindClosestTarget(randomSpot.position, "Player", "Knight");
                randomEnemy.target = closestTarget;
                if(i == currentWave.count -1){
                    finishedSpawning = true;
                }else{
                    finishedSpawning = false;
                }
                yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
            }
        }

    }
    Transform FindClosestTarget(Vector3 position, params string[] tags) {
    Transform closestTarget = null;
    float closestDistance = Mathf.Infinity;

    foreach (string tag in tags) {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in targets) {
            float distanceToTarget = Vector3.Distance(position, target.transform.position);
            if (distanceToTarget < closestDistance) {
                closestTarget = target.transform;
                closestDistance = distanceToTarget;
            }
        }
    }

    return closestTarget;
}
    private void Update() {
        
        if(finishedSpawning==true && GameObject.FindGameObjectsWithTag("Enemy").Length==0 ){
                finishedSpawning=false;
                if(currentWaveIndex +1 < waves.Length){
                    currentWaveIndex++;
                    StartCoroutine(StartNextWave(currentWaveIndex));
                }else{
                   // End of waves
                   Debug.Log("End of wave");
                   InvisibleBorder.SetActive(false);
                   sceneTransfer.CanGo();
                }
        }
    }
}
