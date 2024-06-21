using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheCastleFirstScene : MonoBehaviour, Interactable
{
    public int SceneIndex; // Index of Scene 3
    private bool interacted; // Flag to track if interaction has occurred

    void Start()
    {
        interacted = false;
    }

    public void Interact()
    {
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




