using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    private Vector3 spawnPointPosition; // Position of the spawn point

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

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
       
    }

    
    public void SetSpawnPoint(Vector3 spawnPoint)
    {
        spawnPointPosition = spawnPoint;
    }

    public Vector3 GetSpawnPoint()
    {
        return spawnPointPosition;
    }

    public void ClearSpawnPoint()
    {
        spawnPointPosition = Vector3.zero; 
    }

    public void SpawnPlayerAtSpawnPoint()
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            SpawnPlayerAtSpawnPoint();
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; 
        }
    }
}










