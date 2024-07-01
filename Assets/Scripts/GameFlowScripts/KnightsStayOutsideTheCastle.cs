using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnightsStayOutsideTheCastle : MonoBehaviour
{
    public bool Triggered;
    private static int previousSceneIndex = -1;
    private static KnightsStayOutsideTheCastle Instance;

    public NPCManager nPCManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Triggered = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int currentSceneIndex = scene.buildIndex;

        if (previousSceneIndex == 3 && currentSceneIndex == 1)
        {
            Invoke("CallTheNPCManager", 2f);
        }

        // Update the previousSceneIndex to the current scene's build index
        previousSceneIndex = scene.buildIndex;
    }

    public void CallTheNPCManager()
    {
        if (nPCManager != null)
        {   
            GetComponent<BoxCollider2D>().enabled = false;
            nPCManager.FirstStage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Triggered && other.CompareTag("Player"))
        {
            Triggered = true;
            NPCKnightBehaviour[] knightBehaviours = FindObjectsOfType<NPCKnightBehaviour>();
            GameObject[] defendGameObjects = GameObject.FindGameObjectsWithTag("DefendPoint");
            Transform[] DefendPoints = new Transform[defendGameObjects.Length];
            for (int i = 0; i < defendGameObjects.Length; i++)
            {
                DefendPoints[i] = defendGameObjects[i].transform;
            }

            for (int i = 0; i < knightBehaviours.Length && i < DefendPoints.Length; i++)
            {
                knightBehaviours[i].CanDetectFromFar = false;
                knightBehaviours[i].isFollowing = false;
                knightBehaviours[i].GoToDestination(DefendPoints[i]);
            }
        }
    }
}

