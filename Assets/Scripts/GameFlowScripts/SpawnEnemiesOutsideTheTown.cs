using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesOutsideTheTown : MonoBehaviour
{   

    public GameObject Enemies;
    public Transform[] positions;
    public bool PlayerHasPassed;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHasPassed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (!PlayerHasPassed && other.CompareTag("Player"))
        {
            PlayerHasPassed = true;
            SpawnEnemiesOnPoint();
        }
        
    }
    public void SpawnEnemiesOnPoint(){
        foreach (Transform position in positions)
        {
            Instantiate(Enemies, position.position, position.rotation);
        }
    }
}
