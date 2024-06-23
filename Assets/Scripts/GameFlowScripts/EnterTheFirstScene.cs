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
        Debug.Log("on scene loaded");
        if (SpawnManager.Instance != null)
        {
            Transform spawnPointTransform = SpawnManager.Instance.GetSpawnPoint();
        }
        else
        {
            Debug.LogError("SpawnManager.Instance is null!");
        }
    }

    void SpawnPlayerAtSpawnPoint(Transform spawnPointTransform)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = spawnPointTransform.position;
            player.transform.rotation = spawnPointTransform.rotation;
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















