using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // This method is called when the object is clicked (when the mouse button is released over the object)
    void OnMouseUp()
    {
        Debug.Log("You are clicked!"); // This will display in the Unity console
    }

    // This method is called when the mouse is over the object and pressed down
    void OnMouseDown()
    {
        Debug.Log("Mouse button is pressed on the object.");
    }

    // This method is called when the mouse hovers over the object (optional)
    void OnMouseOver()
    {
        Debug.Log("Mouse is over the object.");
    }
}
