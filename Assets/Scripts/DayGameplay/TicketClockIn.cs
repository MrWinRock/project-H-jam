using UnityEngine;

public class TicketClockIn : MonoBehaviour {
    private Vector3 offset;
    private Camera cam;

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
        // Calculate the offset between the object's position and the mouse position
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        // Update the position of the object with the offset
        Vector3 targetPosition = GetMouseWorldPosition() + offset;

        // Clamp the object's position within the defined boundaries
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        transform.position = targetPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Convert mouse position to world coordinates
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.nearClipPlane; // distance from the camera
        return cam.ScreenToWorldPoint(mousePoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ghost") || collision.CompareTag("Shaman"))
        {
            Destroy(gameObject);
        }
    }
}
