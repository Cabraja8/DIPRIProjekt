using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAlwaysActive : MonoBehaviour
{
    void Awake()
    {

        GameObject forestObject = GameObject.Find("Forest");
        if (forestObject != null)
        {
            forestObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Forest object not found!");
        }
    }

    void Start()
    {
        // Optional: Additional initialization code
    }

    void Update()
    {
        // Optional: Update logic
    }
}
