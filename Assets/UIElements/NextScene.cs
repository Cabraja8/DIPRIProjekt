using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    void OnEnable()
    {
    SceneManager.LoadScene("FirstScene",LoadSceneMode.Single);
    }
}
