using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryLpd : MonoBehaviour
{
    public float countdownTime = 3f; // Set your desired countdown time here
    private float currentTime;

    void Start()
    {
        currentTime = countdownTime; // Initialize the timer with the countdown time
    }

    void Update()
    {
        currentTime -= Time.deltaTime; // Decrease the timer by the time elapsed since the last frame
        if (currentTime <= 0)
        {
            Destroy(gameObject); // Destroy the GameObject when the timer reaches zero
        }
    }
}
