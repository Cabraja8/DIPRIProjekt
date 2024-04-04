using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTheGuards : MonoBehaviour
{      
    public GameObject Guards;
    public GameObject[] spawnPoints; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGuards(){

          if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points defined.");
            return;
        }

        GameObject chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(Guards, chosenSpawnPoint.transform.position, Quaternion.identity);

    }

}
