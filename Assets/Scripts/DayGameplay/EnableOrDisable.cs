using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnableOrDisable : MonoBehaviour
{
    public Image uiImage;

    public void Trigger(){
        if(uiImage.gameObject.activeInHierarchy == false){
            uiImage.gameObject.SetActive(true);
        }
        else{
            uiImage.gameObject.SetActive(false);
        }
    }
}