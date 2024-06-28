using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueEnemy : MonoBehaviour
{
    public bool isAlive = false;
    public GameObject StatuePrefab;


    // This method will be called to make the statue come alive
    public void BecomeAlive()
    {
        isAlive = true;
        
        Debug.Log(name + " has become alive!");
        SpawnStatue();
        GetComponentInChildren<SpriteRenderer>().enabled = false;

    }

    public void SpawnStatue(){
         if (StatuePrefab != null)
        {
          
            Instantiate(StatuePrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("StatuePrefab is not assigned in the Inspector.");
        }
    }


 


}
