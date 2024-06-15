using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxCapacity = 1; 
    public List<StoneType> stones = new List<StoneType>();

    public void AddStone(StoneType stoneType)
    {
        if (stones.Count < maxCapacity)
        {
            stones.Add(stoneType);
            Debug.Log("Stone added to inventory: " + stoneType);
        }
        else
        {
            Debug.Log("Inventory is full. Cannot add more stones.");
        }
    }

    public void RemoveStone(StoneType stoneType)
    {
        stones.Remove(stoneType);
        Debug.Log("Stone removed from inventory: " + stoneType);
    }
}

