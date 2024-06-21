using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWaveSpawner : MonoBehaviour
{
    public ChapterManager chapterManager;
    public GameObject WaveSpawnerTrigger2;

    // Start is called before the first frame update
    void Start()
    {
        if (chapterManager != null && WaveSpawnerTrigger2 != null)
        {
            // Check if the current chapter number is 4
            if (chapterManager.chapterNumber == 4)
            {
                WaveSpawnerTrigger2.SetActive(true);
            }
            else
            {
                WaveSpawnerTrigger2.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("ChapterManager or WaveSpawnerTrigger is not assigned.");
        }
    }
}
