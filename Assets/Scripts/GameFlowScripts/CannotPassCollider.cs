using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannotPassCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCollider(){
        gameObject.SetActive(false);
    }
}
