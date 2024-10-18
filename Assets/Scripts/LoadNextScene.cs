using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private int sceneIndex = 2;

    void OnEnable()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
