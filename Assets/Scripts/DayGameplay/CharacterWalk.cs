using System.Collections;
using UnityEngine;

public class CharacterWalk : MonoBehaviour {
    public Transform targetPosition; // Reference to the middle of the scene where the character should stop
    public float speed = 2f; // Speed at which the character walks

    private bool hasReachedMiddle = false;
    public GameObject prefabToSpawn; // The prefab you want to instantiate
    public Vector3 spawnPosition;
    public Vector3 middlePosition; // Position where the object will be spawned
    public float spawnDelay = 1f;
    private bool hasSpawned = false;
    void Start()
    {

    }
    void Update()
    {
        // Move the character towards the middle of the scene
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

        // Check if the character has reached the target position
        if (Vector2.Distance(transform.position, targetPosition.position) < 0.1f)
        {
                
            // Optionally: Play animation or trigger something when the character stops
            Debug.Log("Character reached the middle of the scene.");
        }
        if (!hasSpawned && Vector2.Distance(transform.position, middlePosition) < 0.01f) 
        {
            SpawnObject();
            hasSpawned = true;
        }
    }
    void SpawnObject()
    {
        // Instantiate the prefab at the spawn position with the default rotation
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        Debug.Log("Object spawned at: " + spawnPosition);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            Destroy(gameObject);
        }
    }
}
