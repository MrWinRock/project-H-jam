using System.Collections;
using UnityEngine;

public class SpawnWithProbability : MonoBehaviour {
    public GameObject object1;
    public GameObject object2;
    public Vector3 spawnPosition;

    [Range(0f, 1f)]
    public float object1Probability = 0.7f;

    private bool isWaiting = false; 

    void Start()
    {
        StartCoroutine(SpawnObjectWithDelay());
    }

    IEnumerator SpawnObjectWithDelay()
    {
        while (true)
        {
            if (GameObject.FindWithTag("Ghost") == null && GameObject.FindWithTag("Shaman") == null && !isWaiting)
            {
                SpawnObjectWithProbability();
            }
            else
            yield return new WaitForSeconds(2f);
        }
    }

    void SpawnObjectWithProbability()
    {
        // Get a random value between 0 and 1
        float randomValue = Random.Range(0f, 1f);

        // Spawn object1 if the random value is less than the probability for object1
        if (randomValue < object1Probability)
        {
            GameObject spawnedObject = Instantiate(object1, spawnPosition, Quaternion.identity);
            Debug.Log("Spawned Object 1 with probability: " + object1Probability);
        }
        else
        {
            // Otherwise, spawn object2
            GameObject spawnedObject = Instantiate(object2, spawnPosition, Quaternion.identity);
            Debug.Log("Spawned Object 2 with remaining probability: " + (1f - object1Probability));
        }
    }
}
