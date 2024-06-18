using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTheDefendPoints : MonoBehaviour
{
       public GameObject TriggerArmTheDefences;

       
    public bool Triggered;


    void Start()
    {
        Triggered = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Triggered && other.CompareTag("Player"))
        {
            Triggered = true;
            TriggerArmTheDefences.SetActive(true);
            FindObjectOfType<TheKing>().RedirectTheKing();
        }
    }
}
