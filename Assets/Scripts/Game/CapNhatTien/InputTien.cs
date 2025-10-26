using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InputTien : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI t;
    [SerializeField] Toggle isDec;
    public void updateMoney(TextMeshProUGUI inputf){
        StartCoroutine(updateMoneyC(inputf));
    }
    IEnumerator updateMoneyC(TextMeshProUGUI inputf){
        
        yield return null;
        

        // inputf.text = inputf.text.Replace("-", "");
        string s = showMoney(inputf.text);

        
        // Debug.Log(s.Length);
        if (s.Length <= 0){
            
        }
        else if (isDec.isOn){
            s = "- " + s;
            t.color = Color.red;
        }
        else {
            s = "+ " + s;
            t.color = Color.green;
        }
        t.text = s;
    }
    string showMoney(string money){
        // Debug.Log(money);
        // Debug.Log(money.Length);
        string s = "";
        string m = money;
        int dem = 0;
        for (int i=m.Length-2; i>=0; i--){
            // Debug.Log(i);
            char c = m[i];
            s = c + s;
            dem++;
            if (i > 0 && dem==3){
                dem = 0;
                s = "." + s;
            }
            // Debug.Log(s);
        }
        return s;
    }
}
