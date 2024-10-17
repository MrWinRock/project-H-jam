using System;
using System.Collections;
using System.Collections.Generic;
using DayGameplay;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckGhost : MonoBehaviour
{
    private bool isChecking = false;
    private GhostList ghostList; // Reference to the GhostList component

    void Start()
    {
        // Get the GhostList component from the scene
        ghostList = FindObjectOfType<GhostList>();
        if (ghostList == null)
        {
            Debug.LogError("GhostList component not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChecking)
        {
            GameObject ghostObject = GameObject.FindWithTag("Ghost");
            GameObject shamanObject = GameObject.FindWithTag("Shaman");

            if (ghostObject == null && shamanObject == null && ghostList != null && ghostList.currentGhostIndex == ghostList.ghosts.Length - 1)
            {
                isChecking = true;
                StartCoroutine(WaitAndLoadNextScene(7f));
            }
        }
    }

    private IEnumerator WaitAndLoadNextScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject); // Destroy this script's GameObject
    }
}