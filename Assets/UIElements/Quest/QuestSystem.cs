using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestSystem
{
    public QuestType questType;
    public GameObject location;
}

public enum QuestType
{
    Fight,
    Location
}