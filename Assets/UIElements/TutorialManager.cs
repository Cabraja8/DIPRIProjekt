using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; // Reference to the panel containing the tutorial

    void Start()
    {
        // Optionally, you can make sure the tutorialPanel is active at the start
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
            PauseGame();
        }
    }

    public void HideTutorial()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false); // Hide the tutorial panel
            UnpauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f; // Unpause the game
    }
}
