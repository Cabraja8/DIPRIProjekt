using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class ThirdChapterStart : ChapterStart
// {

//     private void Awake()
//     {
//         // expectedQuestCount = 4; // Broj questova koji igrač mora završiti prije prelaska u četvrti chapter
//         setCamera = false;
//     }
// }



// public class FifthChapterStart : ChapterStart
// {
//     private void Awake()
//     {
//         // expectedQuestCount = 6; // Broj questova koji igrač mora završiti prije prelaska u četvrti chapter
//         setCamera = false;
//     }
// }

public class ThirdChapterStart : MonoBehaviour
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


            // Disable the current chapter border and enable the back border
            ChapterBorder.SetActive(false);
            BackBorder.SetActive(true);


        }
    }

}