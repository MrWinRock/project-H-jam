using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
public void Play(int sceneIndex)
{
    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
}
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
