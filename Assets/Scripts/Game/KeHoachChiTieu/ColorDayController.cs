using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorDayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<transform.childCount;i++){
            if (i%2==0){
                transform.GetChild(i).GetComponent<Image>().color = new Color(0.87f,0.87f,0.87f,1);
            }
            else {
                transform.GetChild(i).GetComponent<Image>().color = new Color(1,1,1,1);
            }
            
        }   
    }
}
