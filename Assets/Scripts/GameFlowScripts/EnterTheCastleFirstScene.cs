using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheCastleFirstScene : MonoBehaviour, Interactable
{
    public int SceneIndex; 
    private bool interacted; 

    void Start()
    {
        interacted = false;
    }

    public void Interact()
    {
        if (!CanInteract())
            return;

        interacted = true;
        SceneManager.LoadScene(SceneIndex);
    }

    public bool CanInteract()
    {
        return !interacted;
    }

    public void ResetInteraction()
    {
        interacted = false;
    }
}





