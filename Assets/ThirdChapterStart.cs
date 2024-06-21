using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdChapterStart : MonoBehaviour
{
    public GameObject ChapterBorder2;
    public GameObject BackBorder2;
    public GameObject KingDialog;

    public float SetMaxY;
    public float SetMinY;

    public float SetMaxX;
    public float SetMinX;

    private InteractWithKing interactWithKing;

    // Start is called before the first frame update
    void Start()
    {
        BackBorder2.SetActive(false);

        if (KingDialog != null)
        {
            interactWithKing = KingDialog.GetComponent<InteractWithKing>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Provjera ako je igrač bio u interakciji s KingDialog objektom
        if (interactWithKing != null && interactWithKing.IsInteracted)
        {
            // Omogućavanje prijelaza u treći chapter
            CanStartChapter = true;
        }
    }

    private bool CanStartChapter = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (CanStartChapter && other.CompareTag("Player"))
        {
            Debug.Log("Start next chapter");
            ChapterBorder2.SetActive(false);
            BackBorder2.SetActive(true);
            FindObjectOfType<CameraFollow>().SetMaxY(SetMaxY);
            FindObjectOfType<CameraFollow>().SetMinY(SetMinY);
            FindObjectOfType<CameraFollow>().SetMaxX(SetMaxX);
            FindObjectOfType<CameraFollow>().SetMinX(SetMinX);
        }
    }
}
