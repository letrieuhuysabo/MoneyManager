using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ThongBaoPanel : MonoBehaviour
{
    static GameObject panelThongBao;
    [SerializeField] float speed, duration;
    Coroutine coroutine;
    public static ThongBaoPanel instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        panelThongBao = transform.GetChild(0).gameObject;
    }

    public void showThongBao(string s){
        if (coroutine != null)
            StopCoroutine(coroutine);
        panelThongBao.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,241);
        panelThongBao.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = s;
        coroutine = StartCoroutine(movePanel());
    }
    IEnumerator movePanel(){
        RectTransform rectTransform = panelThongBao.GetComponent<RectTransform>();
        
        while (rectTransform.anchoredPosition.y > -133){
            rectTransform.anchoredPosition += new Vector2(0,-1)*speed*Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = new Vector2(0,-133);
        yield return new WaitForSeconds(duration);
        while (rectTransform.anchoredPosition.y < 241){
            rectTransform.anchoredPosition += new Vector2(0,1)*speed*Time.deltaTime;
            yield return null;
        }
    }
    public void closePanel(){
        StopCoroutine(coroutine);
        StartCoroutine(hideThongBao());
    }
    IEnumerator hideThongBao(){
        RectTransform rectTransform = panelThongBao.GetComponent<RectTransform>();
        while (rectTransform.anchoredPosition.y < 241){
            rectTransform.anchoredPosition += new Vector2(0,1)*speed*Time.deltaTime;
            yield return null;
        }
    }
}
