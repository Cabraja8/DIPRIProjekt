using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChapterManager : MonoBehaviour
{
    public GameObject chapterDisplay; // The parent GameObject containing both the text and background image
    public TextMeshProUGUI chapterText; // Assign this in the Inspector
    public float displayDuration = 3f; // Duration for which the text is displayed
    public int chapterNumber = 1; // The chapter number to display

    private void Start()
    {
        // Start displaying the chapter number when the scene loads
        StartCoroutine(DisplayChapterNumber(chapterNumber));
    }

    private IEnumerator DisplayChapterNumber(int chapterNumber)
    {
        // Set the text to the chapter number
        chapterText.text = "Chapter " + chapterNumber.ToString();

        // Show the chapter display (both text and background)
        chapterDisplay.SetActive(true);

        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Hide the chapter display (both text and background)
        chapterDisplay.SetActive(false);
    }
}