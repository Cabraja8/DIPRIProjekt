using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableKingInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<InteractWithKing>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableKingInteract(){
       GetComponent<InteractWithKing>().enabled=true;
    }
}
