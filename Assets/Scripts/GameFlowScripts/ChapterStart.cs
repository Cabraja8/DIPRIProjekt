using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterStart : MonoBehaviour
{

    public bool CanStartChapter;
    public GameObject ChapterBorder;
    public GameObject BackBorder;

    public float SetMaxY;
    public float SetMinY;

    public float SetMaxX;
    public float SetMinX;

    public int expectedQuestCount; // Number of quests needed to complete before triggering this chapter

    // Start is called before the first frame update
    void Start()
    {
        CanStartChapter = false;
        BackBorder.SetActive(false);

        ChapterBorder.SetActive(true);
        QuestManager.OnAllQuestsCompleted += ActivateTrigger;
        QuestManager.Instance.expectedQuestCount = expectedQuestCount;
    }

    public void SetToTrueChapterStart()
    {
        CanStartChapter = true;
    }

    private void OnDestroy()
    {
        QuestManager.OnAllQuestsCompleted -= ActivateTrigger;
    }

    private void ActivateTrigger()
    {
        ChapterBorder.SetActive(false);
        BackBorder.SetActive(true);
        SetChapter();
    }


    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (CanStartChapter)
        {
            Debug.Log("Start next chapter");
            ChapterBorder.SetActive(false);
            BackBorder.SetActive(true);
            SetChapter();
        }
    }

    public void SetChapter()
    {

        FindObjectOfType<CameraFollow>().SetMaxY(SetMaxY);
        FindObjectOfType<CameraFollow>().SetMinY(SetMinY);
        FindObjectOfType<CameraFollow>().SetMaxX(SetMaxX);
        FindObjectOfType<CameraFollow>().SetMinX(SetMinX);
    }


}
