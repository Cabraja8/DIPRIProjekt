using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static Vector3? playerSpawnPosition = null; // Nullable Vector3 to store the spawn position
    public Transform defaultSpawnPoint; // Default spawn point in the scene
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
            if (playerSpawnPosition.HasValue)
            {
                player.transform.position = playerSpawnPosition.Value;
                playerSpawnPosition = null; // Clear the spawn position after use
            }
            else if (defaultSpawnPoint != null)
            {
                player.transform.position = defaultSpawnPoint.position;
                ChapterFinished();
            }
        }
    }

    public void ChapterFinished(){
        FindObjectOfType<CameraFollow>().SetMaxY(SetMaxY);
        FindObjectOfType<CameraFollow>().SetMinY(SetMinY);
        FindObjectOfType<CameraFollow>().SetMaxX(SetMaxX);
        FindObjectOfType<CameraFollow>().SetMinX(SetMinX);
    }
}



