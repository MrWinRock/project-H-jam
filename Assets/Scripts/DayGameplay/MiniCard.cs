using System;
using System.Collections;  // Required for IEnumerator
using System.Collections.Generic;  // Commonly used for lists and collections
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;
public class MiniCard : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;
    private bool isDragging = false;
    private bool isInMachine = false;
    private float minX, maxX, minY, maxY;
    public GameObject uiImage;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiImage.gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the click is on a UI element or an object with a collider
            if (!IsPointerOverUI() && !IsPointerOverGameObject())
            {
                // Click is outside, deactivate the target object
                uiImage.gameObject.SetActive(false);
                Debug.Log("Clicked outside, deactivating the target object.");
            }
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
        if(uiImage.gameObject.activeInHierarchy == true)
        {
            if (uiImage != null)
            {
                uiImage.gameObject.SetActive(false);
            }
        }
        else
        {
            if (uiImage != null)
            {
                uiImage.gameObject.SetActive(true);
            }
        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.nearClipPlane;
        return cam.ScreenToWorldPoint(mousePoint);
    }
    
    
    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    // Check if the mouse pointer is over a 2D/3D object
    private bool IsPointerOverGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == uiImage.gameObject)
            {
                return true; // Clicked on the target object
            }
        }

        return false; // Not clicking on the target object
    }
    
    
}
