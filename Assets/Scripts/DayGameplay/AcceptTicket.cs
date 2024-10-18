using System;
using System.Collections;
using System.Collections.Generic;
using DayGameplay;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AcceptTicket : MonoBehaviour
{
    public Vector3 newPosition;
    public Vector3 oldPosition; // New position to set
    private float currentTime;
    public float countdownTime;
    public GameObject objectToMove;
    public GameObject ticketClockIn;
    private GhostList ghostList; // Reference to GhostList
    ScoreCount score;

    private bool isGhost;

    // Start is called before the first frame update
    void Start()
    {
        ghostList = FindObjectOfType<GhostList>(); // Get the GhostList component from the scene
        score = FindObjectOfType<ScoreCount>();

        currentTime = countdownTime; // Initialize the timer with the 6-minute countdown
    }

    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("Check");
        GameObject foundObject2 = GameObject.FindWithTag("TicketClockIn");

        if (foundObject1 != null)
        {
            currentTime -= Time.deltaTime;
            Console.WriteLine(currentTime);
            if (currentTime <= 0 && objectToMove != null)
            {
                objectToMove.transform.position = oldPosition;
            }
        }
        else
        {
            Debug.Log("Object with tag 'Check' does not exist in the scene.");
        }

        if (ghostList != null)
        {
            isGhost = ghostList.isGhost; // Access the isGhost variable
            Debug.Log("Is Ghost: " + isGhost);
        }
        else
        {
            Debug.LogError("GhostList component not found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.gameObject.name);
        if (collision.CompareTag("TicketClockIn"))
        {
            GameObject foundObject1 = GameObject.FindWithTag("Check");
            if (foundObject1 != null)
            {
                currentTime = 3.3f;
                Debug.Log("Trigger entered by TicketClockIn");

                // Check if the object to move is assigned
                if (objectToMove != null)
                {
                    // Change the position of the object
                    objectToMove.transform.position = newPosition;
                    Debug.Log(objectToMove.name + " moved to: " + newPosition);
                }
                else
                {
                    Debug.LogError("objectToMove is not assigned.");
                }
                // if (ghostList != null && isGhost)
                // {
                //     if (score != null)
                //     {
                //         score.AddScore();
                //         Debug.Log("Score added.");
                //     }
                //     else
                //     {
                //         Debug.LogError("ScoreCount component not found.");
                //     }
                // }
            }
            else
            {
                Debug.Log("Object with tag 'Check' does not exist in the scene.");
            }
        }
    }
}