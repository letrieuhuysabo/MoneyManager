using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sky : MonoBehaviour
{
    RectTransform top, bottom;
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        top = transform.GetChild(1).GetComponent<RectTransform>();
        bottom = transform.GetChild(0).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        top.anchoredPosition += new Vector2(0,-1)*moveSpeed*Time.deltaTime;
        bottom.anchoredPosition += new Vector2(0,-1)*moveSpeed*Time.deltaTime;
        if (bottom.anchoredPosition.y < -450){
            bottom.anchoredPosition = top.anchoredPosition + new Vector2(0,450);
            RectTransform tmp = top;
            top = bottom;
            bottom = tmp;
        }
    }
}
