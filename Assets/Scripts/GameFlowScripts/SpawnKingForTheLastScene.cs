using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKingForTheLastScene : MonoBehaviour
{   

    public GameObject KingPrefab;
    private GameObject spawnedKing;
    public bool GameIsfinished;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GameIsfinished = false;
    }
    public void SpawnKing(){
         if (KingPrefab != null){
            spawnedKing = Instantiate(KingPrefab, transform.position, transform.rotation);
        }
    }

    void Update()
    {
         if (spawnedKing != null && spawnedKing.CompareTag("Dead"))
        {
            if (!GameIsfinished)
            {
                GameIsfinished = true;
                FinishGame();
            }
        }
    }
    public void FinishGame(){
        Debug.Log("GameIsFinished");
    }

}
