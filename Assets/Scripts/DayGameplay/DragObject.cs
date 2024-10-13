using System.Collections;  // Required for IEnumerator
using System.Collections.Generic;  // Commonly used for lists and collections
using UnityEngine;

public class DragObject : MonoBehaviour {
    private Vector3 offset;
    private Camera cam;
    private bool isDragging = false;
    private bool isInMachine = false;

    public Transform machinePosition; // Reference to the machine's input slot position
    public GameObject newObjectPrefab; // Prefab of the new object to instantiate
    private float minX, maxX, minY, maxY;

    void Start()
    {
        cam = Camera.main;

        // Define the world boundaries using the camera's viewport
        Vector3 screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        // Set the boundaries for X and Y (with some margin for the object size)
        minX = screenBottomLeft.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2);
        maxX = screenTopRight.x - (GetComponent<SpriteRenderer>().bounds.size.x / 2);
        minY = screenBottomLeft.y + (GetComponent<SpriteRenderer>().bounds.size.y / 2);
        maxY = screenTopRight.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2);
    }

    void OnMouseDown()
    {
        if (!isInMachine)
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 targetPosition = GetMouseWorldPosition() + offset;

            // Clamp the target position to stay within the defined boundaries
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

            transform.position = targetPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.nearClipPlane;
        return cam.ScreenToWorldPoint(mousePoint);
    }

    // Check if the object is close to the machine when released
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ClockMachine"))
        {
            StartCoroutine(SlideIntoMachine());
        }
    }

    // Coroutine to slide the object into the machine with a jerky down animation
    private IEnumerator SlideIntoMachine()
    {
        isInMachine = true;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(startPos.x, machinePosition.position.y, startPos.z); // Keep the X position, change Y to the machine's Y
        float elapsedTime = 0f;
        float duration = 0.7f; // Total duration of the sliding (1 second)

        // Jerky down animation logic
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Jerky effect by using a sine function for downward motion
            float t = Mathf.PingPong(elapsedTime * 3, 1); // Increased speed for a more pronounced jerky effect
            float newY = Mathf.Lerp(startPos.y, endPos.y, t); // Lerp between start and end Y positions

            // Keep X constant while moving Y
            transform.position = new Vector3(startPos.x, newY, startPos.z);

            yield return null;
        }

        // Ensure the final position is exactly at the machine
        transform.position = endPos;

        // After it slides in, replace the object
        ReplaceObject();
    }

    // Function to replace the object with a new one
    private void ReplaceObject()
    {
        // Instantiate the new object prefab at the output position
        InstantiateNewObject();

        // Destroy the original object after a brief delay to allow the animation to complete
        Destroy(gameObject, 0.1f); // Delay of 0.1 seconds
    }

    // Function to instantiate a new object that can be dragged
    private void InstantiateNewObject()
    {
        // Instantiate the new object prefab at a position slightly to the right of the machine
        GameObject newObject = Instantiate(newObjectPrefab, transform.position + new Vector3(2f, 0, 0), Quaternion.identity);
        newObject.AddComponent<DragObject>(); // Add DragObject script to the new object
        // Optionally, set any other properties on the new object here
    }
}