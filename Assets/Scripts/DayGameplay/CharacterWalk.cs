using System.Collections;
using UnityEngine;

public class CharacterWalk : MonoBehaviour {
    public Transform targetPosition; // Reference to the middle of the scene where the character should stop
    public float speed = 2f; // Speed at which the character walks

    private bool hasReachedMiddle = false;

    void Update()
    {
        if (!hasReachedMiddle)
        {
            // Move the character towards the middle of the scene
            transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

            // Check if the character has reached the target position
            if (Vector2.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                hasReachedMiddle = true;
                // Optionally: Play animation or trigger something when the character stops
                Debug.Log("Character reached the middle of the scene.");
            }
        }
    }
}
