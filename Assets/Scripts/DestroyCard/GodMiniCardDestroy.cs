using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMiniCardDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("God");
        if (foundObject1 == null)
        {
            Destroy(gameObject);
        }
    }
}
