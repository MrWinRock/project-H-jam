using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanMiniCardDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("Nan");
        if (foundObject1 == null)
        {
            Destroy(gameObject);
        }
    }
}
