using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{   
    public bool CanGoToOtherScene;

    // Start is called before the first frame update
    void Start()
    {
        CanGoToOtherScene = false;
    }

    public void CanGo(){
        CanGoToOtherScene = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(CanGoToOtherScene){
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }


}
