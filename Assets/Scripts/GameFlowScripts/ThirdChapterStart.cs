using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdChapterStart : ChapterStart
{

    private void Awake()
    {
        expectedQuestCount = 4; // Broj questova koji igrač mora završiti prije prelaska u četvrti chapter
        setCamera = false;
    }
}


