
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheFirstScene : MonoBehaviour, Interactable
{
    public int SceneIndex; // Index of the First Scene in the Build Settings
    public bool Interacted;

    void Start()
    {
        Interacted = false;
    }

    public void Interact()
    {
        Interacted = true;
        SceneManager.LoadScene(SceneIndex);
    }

    public bool CanInteract()
    {
        Invoke("ResetInteraction", 2f);
        return !Interacted;
    }

    public void ResetInteraction()
    {
        Interacted = false;
    }
}
