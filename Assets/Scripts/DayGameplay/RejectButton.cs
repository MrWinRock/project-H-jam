using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectButton : MonoBehaviour {
    public GameObject objectToActivate;   // Object to activate
    public GameObject objectToDestroy;    // Object to destroy  // Script to enable
    public GameObject objectToMove;
    public GameObject ticketClockIn;// Object to move
    public GameObject prefabToActive;
    public Vector3 newPosition;
    public Vector3 oldPosition;
    public float countdownTime;           // New position to set
    private float currentTime;
    public Vector3 spawnPosition1;
    private bool hasSpawned = false;

    void Start()
    {
        currentTime = countdownTime;  // Initialize the timer with the 6-minute countdown
    }
    // Update is called once per frame
    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("Check");
        GameObject foundObject2 = GameObject.FindWithTag("TicketClockIn");
        if (foundObject2 == null && foundObject1 == null)
        {
            currentTime -= Time.deltaTime;
            Console.WriteLine(currentTime);
            if (currentTime <= 0)
            {
                objectToMove.transform.position = oldPosition;
                prefabToActive.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Object with tag exist in the scene.");
        }
    }

    // This method is called when the mouse button is pressed over the object
    private void OnMouseDown()
    {
        if (GameObject.FindWithTag("Check") == null)
        {
            currentTime = 3.3f;
            Debug.Log("Mouse Down on RejectButton!");

            // Check if the object to move is assigned
            if (objectToMove != null)
            {
                // Change the position of the object
                objectToMove.transform.position = newPosition;
                Debug.Log(objectToMove.name + " moved to: " + newPosition);
                prefabToActive.SetActive(true);
            }
            if (objectToDestroy.scene.isLoaded) // Check if the GameObject is in a loaded scene
            {
                Destroy(objectToDestroy);
            }
        }
    }
    

    // Optional: This method is called when the mouse hovers over the object
    private void OnMouseOver()
    {
        Debug.Log("Mouse is over the object.");
    }

    // Optional: This method is called when the mouse button is released over the object
    private void OnMouseUp()
    {
        Debug.Log("You clicked and released the mouse!");
    }
}