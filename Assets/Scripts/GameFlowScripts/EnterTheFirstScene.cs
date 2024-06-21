using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheFirstScene : MonoBehaviour, Interactable
{
    public int sceneIndex; // Index of Scene 1
    private bool interacted; // Flag to track if interaction has occurred

    void Start()
    {
        interacted = false;
    }

    public void Interact()
    {
        if (!CanInteract())
            return;

        interacted = true;

        // Load Scene 1
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

    // This method is called when Scene 1 is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if SpawnManager.Instance is valid
        if (SpawnManager.Instance != null)
        {
            // Retrieve spawn point from the spawn manager
            Vector3 spawnPointPosition = SpawnManager.Instance.GetSpawnPoint();

            // Example: You might want to set this spawn point in another manager or script
            // For demonstration, we'll try to spawn the player at this position
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
        // Register callback for scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Deregister callback to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}













