using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GunMiniCardDestroy : MonoBehaviour
{
    // Reference to the GunMiniCard prefab

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject foundObject1 = GameObject.FindWithTag("Gun");
        if (foundObject1 == null)
        {
            Destroy(gameObject);
        }
    }
}
