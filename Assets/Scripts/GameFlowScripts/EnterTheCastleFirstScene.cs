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
        // Optionally, you can add a transition effect here
        yield return SceneManager.LoadSceneAsync(sceneIndex);

        // After loading the new scene, set up any necessary components
        SetupSceneForQuests();
    }

    private void SetupSceneForQuests()
    {
        // Find the SceneInitializer in the new scene and call Initialize
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
