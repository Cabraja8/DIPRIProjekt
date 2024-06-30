using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveUndead : MonoBehaviour
{   
    public bool PlayerHasPassed;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        PlayerHasPassed = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !PlayerHasPassed)
        {
            PlayerHasPassed = true;

            Undead[] undead = FindObjectsOfType<Undead>();

            foreach (Undead undeadObject in undead)
            {
                Destroy(undeadObject.gameObject);
            }
        }
    }
}
