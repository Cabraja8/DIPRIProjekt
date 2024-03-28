using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : MonoBehaviour
{

    public GameObject WaveSpawner;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        WaveSpawner.SetActive(false);
    }


        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player"){
                Debug.Log("Wave Spawner activated");
                WaveSpawner.SetActive(true);
            }
        }
  
}
