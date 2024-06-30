
// public class FourthChapterStart : ChapterStart
// {
//     private void Awake()
//     {
//         // expectedQuestCount = 3; // Broj questova koji igrač mora završiti prije prelaska u četvrti chapter
//         setCamera = false;
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthChapterStart : MonoBehaviour
{
    public GameObject ChapterBorder;
    public static bool beenInFourthChapter = false;
    // public GameObject BackBorder;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        ChapterBorder.SetActive(true);

    }

    // Trigger method when player enters the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            beenInFourthChapter = true;

            // Disable the current chapter border 
            ChapterBorder.SetActive(false);



        }
    }
}
