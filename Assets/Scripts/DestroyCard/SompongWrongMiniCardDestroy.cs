using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SompongWrongMiniCardDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("SompongWrong");
        if (foundObject1 == null)
        {
            Destroy(gameObject);
        }
    }
}
