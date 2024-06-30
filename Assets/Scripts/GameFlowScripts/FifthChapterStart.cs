
// public class FifthChapterStart : ChapterStart
// {
//     private void Awake()
//     {
//         // expectedQuestCount = 6; // Broj questova koji igrač mora završiti prije prelaska u peti chapter
//         setCamera = false;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthChapterStart : MonoBehaviour
{

    public GameObject ChapterBorder;
    public GameObject BackBorder;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        BackBorder.SetActive(false);
        ChapterBorder.SetActive(true);


    }

    // Trigger method when player enters the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Assuming the player has a tag "Player"
        {
            // Check if the player has completed the fourth chapter
            if (FourthChapterStart.beenInFourthChapter)
            {

                // Disable the current chapter border and enable the back border
                ChapterBorder.SetActive(false);
                BackBorder.SetActive(true);


            }
        }

    }
}
