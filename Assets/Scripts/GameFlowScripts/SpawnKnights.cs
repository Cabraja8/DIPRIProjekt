using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnights : MonoBehaviour
{   


    public GameObject Knight;
    public int numberOfKnights = 4;
    public Transform spawnParent;

    // Start is called before the first frame update
    void Start()
    {   
        // Check if the knightPrefab is assigned
        if (Knight == null)
        {   
            
            Debug.LogError("Knight prefab is not assigned.");
            return;
        }

        // Start the coroutine to spawn knights after a delay
        StartCoroutine(SpawnKnightsWithDelay(0.5f));
    }

    // Coroutine to spawn knights after a delay
    IEnumerator SpawnKnightsWithDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Spawn the specified number of knights
        for (int i = 0; i < numberOfKnights; i++)
        {
            // Instantiate the knight as a child of the current GameObject
            GameObject knight = Instantiate(Knight, spawnParent.position ,Quaternion.identity, spawnParent);

            // Optionally set the local position of the knight (offset for demonstration)
            knight.transform.localPosition = new Vector3(i * 2.0f, 0, 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
