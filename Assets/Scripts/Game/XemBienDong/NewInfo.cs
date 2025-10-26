using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewInfo : MonoBehaviour
{
    [SerializeField] TMP_InputField ip1,ip2;
    [SerializeField] Toggle t;
    void OnEnable(){
        t.isOn = false;
        ip1.text ="";
        ip2.text ="";
    }
}
