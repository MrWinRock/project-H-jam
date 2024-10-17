using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AcceptTicket : MonoBehaviour
{
    public Vector3 newPosition;
    public Vector3 oldPosition;          // New position to set
    private float currentTime;
    public float countdownTime;
    public GameObject objectToMove;
    public GameObject ticketClockIn;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = countdownTime;  // Initialize the timer with the 6-minute countdown
    }

    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("Check");
        GameObject foundObject2 = GameObject.FindWithTag("TicketClockIn");
        if (foundObject1 != null)
        {
            currentTime -= Time.deltaTime;
            Console.WriteLine(currentTime);
            if (currentTime <= 0)
            {
                objectToMove.transform.position = oldPosition;
            }
        }
        else
        {
            Debug.Log("Object with tag not exist in the scene.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TicketClockIn"))
        {   
            GameObject foundObject1 = GameObject.FindWithTag("Check");
            if (foundObject1 != null)
            {
                currentTime = 15f;

                // Check if the object to move is assigned
                if (objectToMove != null)
                {
                    // Change the position of the object
                    objectToMove.transform.position = newPosition;
                }
            }
        }
    }
}
