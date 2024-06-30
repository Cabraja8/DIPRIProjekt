using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartThisDialog : MonoBehaviour
{
    public GameObject KingOutpost;

    // Start is called before the first frame update
    void Start()
    {

        // Initially set the state based on whether the fourth chapter is completed
        UpdateDialogState();
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously check if the fourth chapter is completed and update the dialog state
        UpdateDialogState();
    }

    void UpdateDialogState()
    {
        if (FourthChapterStart.beenInFourthChapter)
        {
            KingOutpost.SetActive(true);
        }
        else
        {
            KingOutpost.SetActive(false);
        }
    }
}
