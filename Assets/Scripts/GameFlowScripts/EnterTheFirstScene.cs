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

        // Store spawn point information
        if (spawnPoint != null)
        {
            SpawnManager.playerSpawnPosition = spawnPoint.position;
            PlayerPrefs.SetInt("ActivateSpawnPoint", 1); // Set a flag to activate the spawn point
            PlayerPrefs.Save(); // Ensure the PlayerPrefs are saved
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







