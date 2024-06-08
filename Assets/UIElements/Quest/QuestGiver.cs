using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver: MonoBehaviour
{
    public Quest quest;
    public Player player;

    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI  descriptionText; 
    
    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text=quest.title;
        descriptionText.text=quest.description;
    }
}