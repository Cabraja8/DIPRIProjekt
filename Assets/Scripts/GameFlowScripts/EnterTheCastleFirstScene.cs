using System.Collections; // Ensure this is added
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
        StartCoroutine(LoadSceneAndSetup(SceneIndex));
    }

    private IEnumerator LoadSceneAndSetup(int sceneIndex)
    {
        yield return SceneManager.LoadSceneAsync(sceneIndex);
        SetupSceneForQuests();
    }

    private void SetupSceneForQuests()
    {
        SceneInitializer sceneInitializer = FindObjectOfType<SceneInitializer>();
        if (sceneInitializer != null)
        {
            sceneInitializer.Initialize();
        }
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
