using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : MonoBehaviour
{

    public GameObject WaveSpawner;
    public bool NotStarted;
    public GameObject InvisibleBorder;

 void Awake()
    {
        InvisibleBorder.SetActive(false);
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        WaveSpawner.SetActive(false);
        InvisibleBorder.SetActive(false);
        NotStarted = false;
    }


        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player" && !NotStarted){
                Debug.Log("Wave Spawner activated");
                NotStarted = true;
                WaveSpawner.SetActive(true);
                WaveSpawner.GetComponent<WaveSpawner>().StartSpawning();
                InvisibleBorder.SetActive(true);
            }
        }

    public void DisableBorder(){
        InvisibleBorder.SetActive(false);
    }
  
}
