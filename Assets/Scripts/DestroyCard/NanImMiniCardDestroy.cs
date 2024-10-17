using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanImMiniCardDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("NanIm");
        if (foundObject1 == null)
        {
            Destroy(gameObject);
        }
    }
}
