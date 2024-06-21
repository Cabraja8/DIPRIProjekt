using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthChapterStart : MonoBehaviour
{
    public GameObject ChapterBorder;
    public GameObject BackBorder;

    //quest koji je obavljen

    public float SetMaxY;
    public float SetMinY;

    public float SetMaxX;
    public float SetMinX;

    // Start is called before the first frame update
    void Start()
    {
        BackBorder.SetActive(false);

        //  ako dođe do tog triggera
    }

    // Update is called once per frame
    void Update()
    {
        // if odrađen quest

        {
            // omogućen novi chapter
            CanStartChapter = true;
        }
    }

    private bool CanStartChapter = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (CanStartChapter && other.CompareTag("Player"))
        {
            Debug.Log("Start next chapter");
            ChapterBorder.SetActive(false);
            BackBorder.SetActive(true);
            FindObjectOfType<CameraFollow>().SetMaxY(SetMaxY);
            FindObjectOfType<CameraFollow>().SetMinY(SetMinY);
            FindObjectOfType<CameraFollow>().SetMaxX(SetMaxX);
            FindObjectOfType<CameraFollow>().SetMinX(SetMinX);
        }
    }
}
