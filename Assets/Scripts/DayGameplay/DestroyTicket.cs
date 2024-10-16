using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyTicket : MonoBehaviour
{
    public Transform GhostPosition; // Reference to the middle of the scene where the character should stop
    public Vector3 middlePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("Ghost");
        GameObject foundObject2 = GameObject.FindWithTag("Shaman");
        if (foundObject1 == null && foundObject2 == null)
        {
            Destroy(gameObject);
        }
    }
}
