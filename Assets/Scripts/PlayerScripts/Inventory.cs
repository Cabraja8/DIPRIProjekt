using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxCapacity = 1; 
    public List<GameObject> stones = new List<GameObject>();

    public void AddStone(GameObject stone)
    {
        if (stones.Count < maxCapacity)
        {
            stones.Add(stone);
            Debug.Log("Stone added to inventory: " + stone.GetComponent<Stone>().stoneType);
        }
        else
        {
            Debug.Log("Inventory is full. Cannot add more stones.");
        }
    }
}
