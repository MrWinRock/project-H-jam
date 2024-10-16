using System;
using System.Collections;  // Required for IEnumerator
using System.Collections.Generic;  // Commonly used for lists and collections
using UnityEngine;
using UnityEngine.UI; 

public class MiniCard : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;
    private bool isDragging = false;
    private bool isInMachine = false;
    private float minX, maxX, minY, maxY;
    public Image uiImage;

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

    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("Ghost");
        GameObject foundObject2 = GameObject.FindWithTag("Shaman");
        if (foundObject1 == null && foundObject2 == null)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();
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
}
