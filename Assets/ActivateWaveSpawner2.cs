// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ActivateWaveSpawner : MonoBehaviour
// {
//     public ChapterManager chapterManager;
//     public GameObject WaveSpawnerTrigger2;

//     // // Start is called before the first frame update
//     // void Start()
//     // {
//     //     if (chapterManager != null && WaveSpawnerTrigger2 != null)
//     //     {

//     //         // Check if the current chapter number is 4
//     //         if (chapterManager.chapterNumber == 4)
//     //         {
//     //             WaveSpawnerTrigger2.SetActive(true);
//     //         }
//     //         else
//     //         {
//     //             WaveSpawnerTrigger2.SetActive(false);
//     //         }
//     //     }
//     //     else
//     //     {
//     //         Debug.LogError("ChapterManager or WaveSpawnerTrigger is not assigned.");
//     //     }
//     // }

//     // Start is called before the first frame update
//     void Start()
//     {
//         if (chapterManager == null || WaveSpawnerTrigger2 == null)
//         {
//             Debug.LogError("ChapterManager or WaveSpawnerTrigger2 is not assigned.");
//             return;
//         }

//         // Initially set the state based on the current chapter
//         UpdateWaveSpawnerState();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // Continuously check the chapter number and update the Wave Spawner state
//         UpdateWaveSpawnerState();
//     }

//     void UpdateWaveSpawnerState()
//     {
//         if (chapterManager.chapterNumber == 4)
//         {
//             WaveSpawnerTrigger2.SetActive(true);
//         }
//         else
//         {
//             WaveSpawnerTrigger2.SetActive(false);
//         }
//     }
// }


///odustajem od chapter managera
///skripta kad je bio već u 4 chpt 
///

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWaveSpawner : MonoBehaviour
{
    public GameObject WaveSpawnerTrigger2;

    // Start is called before the first frame update
    void Start()
    {
        if (WaveSpawnerTrigger2 == null)
        {
            Debug.LogError("WaveSpawnerTrigger2 is not assigned.");
            return;
        }

        // Initially set the state based on whether the fourth chapter is completed
        UpdateWaveSpawnerState();
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously check if the fourth chapter is completed and update the Wave Spawner state
        UpdateWaveSpawnerState();
    }

    void UpdateWaveSpawnerState()
    {
        if (FourthChapterStart.beenInFourthChapter)
        {
            WaveSpawnerTrigger2.SetActive(true);
        }
        else
        {
            WaveSpawnerTrigger2.SetActive(false);
        }
    }
}
