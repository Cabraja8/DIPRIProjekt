using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
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

   

    public ChapterStart chapter;

    public StartWave waveStarter;

    // Add a reference to the Quest or QuestGiver
    public Quest questToTrigger; // Option 1: Direct reference to the quest
  

    private void Start()
    {   
        
        //MakeKnightsAttack();
    }

    public void StartSpawning(){
        Debug.Log("Spawning");

        player = GameObject.FindGameObjectWithTag("Player").transform;
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
                waveStarter.DisableBorder();
                chapter.SetToTrueChapterStart();
               Invoke("FollowPlayerKnights",2f);

                // Trigger the quest after all waves have ended
                TriggerQuestAfterWaves();
            }
        }
    }

    //Quest
    private void TriggerQuestAfterWaves()
    {
        // Option 1: Trigger a specific quest
        if (questToTrigger != null)
        {
            QuestManager.Instance.AddQuest(questToTrigger);
        }
    }

    public void FollowPlayerKnights(){
    NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours) {
    Debug.Log("follow player");
    knightBehaviour.Target = null;
    knightBehaviour.isFollowing = true;
    
}
}

public void MakeKnightsAttack(){
     NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours) {
    Debug.Log("follow player");
    knightBehaviour.CanDetectFromFar = false;
    
    
}
}

public void DontAttackKnights(){
    NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours) {
    Debug.Log("follow player");
    knightBehaviour.CanDetectFromFar = true;
    
    
}
}
}
