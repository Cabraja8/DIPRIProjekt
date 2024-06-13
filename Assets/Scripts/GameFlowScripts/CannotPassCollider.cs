using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannotPassCollider : MonoBehaviour
{   
    public bool Triggered;
    // Start is called before the first frame update
    void Start()
    {   
        Triggered = false;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCollider(){
        if(!Triggered){
        Triggered = true;
        gameObject.SetActive(false);
        }
    }
}
