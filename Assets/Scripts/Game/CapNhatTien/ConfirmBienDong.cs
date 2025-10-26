using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ConfirmBienDong : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText, chuThichText, moneyIP;
    [SerializeField] TMP_InputField chuThichIP;
    void OnEnable(){
        moneyText.text = moneyIP.text;
        if (moneyText.text[0] == '-'){
            moneyText.color = Color.red;
        }
        else {
            moneyText.color = Color.green;
        }
        chuThichText.text = chuThichIP.text;
        if (chuThichText.text == ""){
            chuThichText.text = "Khong co chu thich";
        }
    }
}
