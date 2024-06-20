using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheFirstScene : MonoBehaviour, Interactable
{
    public int sceneIndex; // Index of the scene to load
    public Transform spawnPoint; // Reference to the spawn point transform
    private bool interacted; // Flag to track if interaction has occurred

    void Start()
    {
        interacted = false;
    }

    public void Interact()
    {
        interacted = true;

        // Set the spawn point in the SpawnManager
        if (spawnPoint != null)
        {
            SpawnManager.playerSpawnPosition = spawnPoint.position;
        }

        // Load the scene specified by sceneIndex
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
}



