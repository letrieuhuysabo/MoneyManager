using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerResetPos : MonoBehaviour
{
    RectTransform rectTransform;
    void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }
    void OnEnable()
    {
        rectTransform.anchoredPosition = new Vector2(0,0);
    }
}
