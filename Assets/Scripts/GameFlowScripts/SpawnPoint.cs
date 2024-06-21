using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void Start()
    {
        // Set this spawn point as the default spawn point in the SpawnManager
        SpawnManager.Instance.SetSpawnPoint(transform.position);
    }
}
