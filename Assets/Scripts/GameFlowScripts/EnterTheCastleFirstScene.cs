using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheCastleFirstScene : MonoBehaviour, Interactable
{   
    public int SceneIndex;
    public bool Interacted;
    // Start is called before the first frame update
    void Start()
    {
        Interacted = false;
    }

    
    public void Interact()
    {
        Interacted = true;
        SceneManager.LoadScene(SceneIndex);
        
    }

    public bool CanInteract(){
        Invoke("ResetInteraction",2f);
        return !Interacted;
    }   
     public void ResetInteraction(){
        Interacted = false;
    }
}
