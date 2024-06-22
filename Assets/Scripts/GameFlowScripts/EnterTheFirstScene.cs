using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheFirstScene : MonoBehaviour, Interactable
{
    public int sceneIndex; 
    public bool interacted; 

    void Start()
    {
        interacted = false;
    }

    public void Interact()
    {
        if (!CanInteract())
            return;

        interacted = true;
        SceneManager.LoadScene(sceneIndex);
    }

    public bool CanInteract()
    {
        return !interacted;
    }

    public void ResetInteraction()
    {
        interacted = false;
    }

   
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (SpawnManager.Instance != null)
        {
         
            Vector3 spawnPointPosition = SpawnManager.Instance.GetSpawnPoint();
            SpawnPlayerAtSpawnPoint(spawnPointPosition);
        }
        else
        {
            Debug.LogError("SpawnManager.Instance is null!");
        }
    }

    void SpawnPlayerAtSpawnPoint(Vector3 spawnPointPosition)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = spawnPointPosition;
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
        }
    }

    void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}













