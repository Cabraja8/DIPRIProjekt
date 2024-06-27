using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SpawnEnemiesInCastle : MonoBehaviour
{   
    public GameObject enemyPrefab; 
    public Transform[] SpawnPoints;

    public bool OpenedDoor;

    public OpenTheDoorInsideTheCastle open;


    // Start is called before the first frame update
    void Start()
    {   
        OpenedDoor = false;
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {

        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !OpenedDoor){
            OpenedDoor = true;
            Invoke("OpenTheDoor",2f);
        }
        
    }

    public void SpawnEnemies()
    {
        
        int enemiesToSpawn = Mathf.Min(SpawnPoints.Length, SpawnPoints.Length);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Transform spawnPoint = SpawnPoints[i];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void OpenTheDoor(){
        FollowPlayerKnights();
        ChangeDoor();
    }


      public void FollowPlayerKnights(){
    NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
foreach (NPCKnightBehaviour knightBehaviour in knightBehaviours) {
    Debug.Log("follow player");
    knightBehaviour.Target = null;
    knightBehaviour.isFollowing = true;
    
}
}
    public void ChangeDoor(){
        open.OpenDoor();
    }

}

