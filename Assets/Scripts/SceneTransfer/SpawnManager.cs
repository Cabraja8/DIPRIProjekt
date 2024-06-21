using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static Vector3? playerSpawnPosition = null; // Nullable Vector3 to store the spawn position
    public Transform defaultSpawnPoint; // Default spawn point in the scene
    public Transform specificSpawnPoint; // The specific spawn point to activate
    public float SetMaxY;
    public float SetMinY;
    public float SetMaxX;
    public float SetMinX;

    private void Awake()
    {
        // Ensure this GameObject persists across scene loads
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the player GameObject and move it to the spawn point
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (PlayerPrefs.GetInt("ActivateSpawnPoint", 0) == 1 && specificSpawnPoint != null)
            {
                specificSpawnPoint.gameObject.SetActive(true);
                player.transform.position = specificSpawnPoint.position;
                PlayerPrefs.SetInt("ActivateSpawnPoint", 0); // Reset the flag
                PlayerPrefs.Save(); // Ensure the PlayerPrefs are saved
            }
            else if (playerSpawnPosition.HasValue)
            {
                player.transform.position = playerSpawnPosition.Value;
                playerSpawnPosition = null; // Clear the spawn position after use
            }
            else if (defaultSpawnPoint != null)
            {
                player.transform.position = defaultSpawnPoint.position;
            }

            // Call ChapterFinished only if the loaded scene index is 3
            if (scene.buildIndex == 3)
            {
                ChapterFinished();
            }
        }
    }

    public void ChapterFinished()
    {
        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.SetMaxY(SetMaxY);
            cameraFollow.SetMinY(SetMinY);
            cameraFollow.SetMaxX(SetMaxX);
            cameraFollow.SetMinX(SetMinX);
        }
    }
}





