using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void Start()
    {
        SpawnManager.Instance.SetSpawnPoint(transform.position);
    }
}
