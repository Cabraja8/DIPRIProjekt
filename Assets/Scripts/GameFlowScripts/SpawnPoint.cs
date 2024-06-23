using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPoint : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("start of spawn point");
        SpawnManager.Instance.SetSpawnPoint(transform);
    }
}

