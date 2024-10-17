using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;  // Required for IEnumerator
using System.Collections.Generic; 

namespace DayGameplay
{
    public class GhostList : MonoBehaviour
    {
        public GameObject[] ghosts;
        private int currentGhostIndex = 0;
        public float delayBetweenGhosts = 2f; // Delay in seconds
        private bool isWaitingForNextGhost = false; // To ensure no overlapping coroutines
        public bool isGhost;

        void Start()
        {
            // Start
            // Set the first ghost active if the array is not empty
            if (ghosts.Length > 0 && ghosts[currentGhostIndex] != null)
            {
                ghosts[currentGhostIndex].SetActive(true);
            }
        }

        void Update()
        {
            // Check if the current ghost is destroyed and if we're not already waiting to spawn the next ghost
            if (!isWaitingForNextGhost && currentGhostIndex < ghosts.Length && ghosts[currentGhostIndex] == null)
            {
                // Start the coroutine to activate the next ghost with a delay
                StartCoroutine(ActivateNextGhostWithDelay());
            }
            setIsGhost();
        }

        public void setIsGhost()
        {
            if (currentGhostIndex < ghosts.Length && ghosts[currentGhostIndex] != null && ghosts[currentGhostIndex].CompareTag("Ghost"))
            {
                isGhost = true;
            }
            else
            {
                isGhost = false;
            }
        }
        
        IEnumerator ActivateNextGhostWithDelay()
        {
            isWaitingForNextGhost = true; // Prevent additional coroutines from starting

            yield return new WaitForSeconds(delayBetweenGhosts); // Wait for the specified delay

            currentGhostIndex++; // Move to the next ghost

            // Check if the next ghost is within bounds and activate it
            if (currentGhostIndex < ghosts.Length && ghosts[currentGhostIndex] != null)
            {
                ghosts[currentGhostIndex].SetActive(true);
            }

            isWaitingForNextGhost = false; // Allow the next coroutine to start once this one finishes
        }
    }
}