using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NutAudoAddMoney : MonoBehaviour
{
    public void CD(){
        StartCoroutine(CoolDownCoroutine());
    }
    IEnumerator CoolDownCoroutine(){
        Debug.Log("hello");
        for (int i=0;i<transform.childCount;i++){
            transform.GetChild(i).GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f,1);
        }
        yield return new WaitForSecondsRealtime(2);
        for (int i=0;i<transform.childCount;i++){
            transform.GetChild(i).GetComponent<Image>().color = new Color(0f,1f,0f,1);
        }
    }
}
