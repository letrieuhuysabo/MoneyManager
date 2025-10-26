using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FeaturesHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Coroutine fadeC, unfadeC;
    [SerializeField] float timeFade;
    void OnEnable(){
        GetComponent<Image>().color = Color.white;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("enter");
        if (unfadeC != null){
            StopCoroutine(unfadeC);
            unfadeC = null;
        }
        fadeC = StartCoroutine(fade());
        // transform.localScale = scaleHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("exit");
        if (fadeC != null){
            StopCoroutine(fadeC);
            fadeC = null;
        }
        unfadeC = StartCoroutine(unfade());
        // transform.localScale = scaleDefault;
    }
    IEnumerator fade(){
        float tmp = timeFade;
        Color c = GetComponent<Image>().color;
        while (tmp > 0){
            float m = Mathf.Lerp(0.5f,1f,tmp/timeFade);
            c = new Color(m,m,m,1);
            GetComponent<Image>().color = c;
            tmp -= Time.deltaTime;
            yield return null;
        }
        fadeC = null;
    }
    IEnumerator unfade(){
        float tmp = 0;
        Color c = GetComponent<Image>().color;
        while (tmp < timeFade){
            float m = Mathf.Lerp(0.5f,1f,tmp/timeFade);
            c = new Color(m,m,m,1);
            GetComponent<Image>().color = c;
            tmp += Time.deltaTime;
            yield return null;
        }
        unfadeC = null;
    }
}
