using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheck : MonoBehaviour
{
public GameObject prefabToSpawn; // The prefab you want to instantiate
public Vector3 spawnPosition;
public Vector3 middlePosition; // Position where the object will be spawned
public float spawnDelay = 0.01f;
private bool hasSpawned = false;

    void Start()
    {
        // Start the coroutine to spawn the object after a delay
        SpawnObjects();
    }

    void Update()
    {
        
    }

    void SpawnObjects()
    {
        // Instantiate the prefabs at the spawn position with the default rotation
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        Debug.Log("Objects spawned at: " + spawnPosition);
    }

}
