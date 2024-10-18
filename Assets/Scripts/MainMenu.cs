using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MenuScreen");
    }
    
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}