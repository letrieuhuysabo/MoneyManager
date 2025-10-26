using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class BeginEffectController : MonoBehaviour
{
    [SerializeField] RectTransform moneyText, subMoneyText, nameText;
    [SerializeField] List <RectTransform> features;
    string moneyContent, subMoneyContent, nameContent;
    void OnEnable()
    {
        int money = 0;
        try
        {
            money = SaveAndLoadSystem.Load().money;
        }
        catch(NullReferenceException){}
        //
        moneyText.GetComponent <TextMeshProUGUI>().text = Configs.formatMoney(money + "");
        // return;
        //
        StartCoroutine(showMoneyText(moneyText.GetComponent<AppearDuration>().getDuration()));
        StartCoroutine(showSubMoneyText(subMoneyText.GetComponent<AppearDuration>().getDuration()));
        // StartCoroutine(showNameText(nameText.GetComponent<AppearDuration>().getDuration()));
    }
    void OnDisable()
    {
        moneyText.GetComponent<TextMeshProUGUI>().text = moneyContent;
        subMoneyText.GetComponent <TextMeshProUGUI>().text = subMoneyContent;
        nameText.GetComponent <TextMeshProUGUI>().text = nameContent;
        // Debug.Log(moneyContent + " _ " + subMoneyContent + " _ " + nameContent);
    }
    IEnumerator showNameText(float duration){
        yield return null;
        
        float tmp = 0;
        // yield return null;
        string s = nameText.GetComponent<TextMeshProUGUI>().text;
        nameContent = s;
        nameText.GetComponent<TextMeshProUGUI>().text = "";
        while (tmp < duration){
            tmp += Time.deltaTime;
            nameText.GetComponent<TextMeshProUGUI>().text = s.Substring(0,(int)((tmp/duration)*s.Length));
            // if (Input.GetKeyDown(KeyCode.Mouse0)){
            //     break;
            // }
            yield return null;
        }
        nameText.GetComponent<TextMeshProUGUI>().text = s;
    }
    IEnumerator showMoneyText(float duration){
        yield return null;
        // moneyText.GetComponent<TextMeshProUGUI>().text = FindObjectOfType<LichSuBienDong>().getMoney() + "";
        float s = float.Parse(moneyText.GetComponent<TextMeshProUGUI>().text.Replace(".","").Replace(" đ",""));
        moneyContent = Configs.formatMoney(s.ToString("F0"));
        // s là số tiền cần hiện
        float tmp = 0;
        while (tmp < duration){
            tmp += Time.deltaTime;
            
            moneyText.GetComponent<TextMeshProUGUI>().text = Configs.formatMoney(Mathf.Lerp(0, s,tmp/duration).ToString("F0"));
            yield return null;
        }
        moneyText.GetComponent<TextMeshProUGUI>().text = Configs.formatMoney(s.ToString("F0"));
        
    }
    IEnumerator showSubMoneyText(float duration){
        yield return null;
        // moneyText.GetComponent<TextMeshProUGUI>().text = FindObjectOfType<LichSuBienDong>().getMoney() + "";
        float s = float.Parse(subMoneyText.GetComponent<TextMeshProUGUI>().text.Replace(".","").Replace(" đ)","").Replace("(",""));
        subMoneyContent = "(" + Configs.formatMoney(s.ToString("F0")) + " )";
        // s là số tiền cần hiện
        float tmp = 0;
        while (tmp < duration){
            tmp += Time.deltaTime;
            subMoneyText.GetComponent<TextMeshProUGUI>().text = "(" + Configs.formatMoney(int.Parse(Mathf.Lerp(0, s,tmp/duration).ToString("F0")) + "") + " )";
            yield return null;
        }
        subMoneyText.GetComponent<TextMeshProUGUI>().text = "(" + Configs.formatMoney(s.ToString("F0")) + " )";
        
    } 
}
