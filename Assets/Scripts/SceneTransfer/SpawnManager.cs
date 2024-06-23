using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    private Transform spawnPoint; 
    private const string PreviousSceneKey = "PreviousScene";

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

    public void SetSpawnPoint(Transform spawnPointTransform)
    {
        spawnPoint = spawnPointTransform;
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public void ClearSpawnPoint()
    {
        spawnPoint = null;
    }

    public void SpawnPlayerAtSpawnPoint()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("Spawn point is not set!");
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);

       
        int previousSceneIndex = PlayerPrefs.GetInt(PreviousSceneKey, -1);

        if (previousSceneIndex == 3 && scene.buildIndex == 1)
        {
        
            Debug.Log("Previous scene was 3, current scene is 1. Spawning at specific point.");
            FindObjectOfType<ChapterStart>().SetChapter();
            SpawnPlayerAtSpawnPoint();
        }

        PlayerPrefs.SetInt(PreviousSceneKey, scene.buildIndex);
        PlayerPrefs.Save();
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}














