using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearButton : MonoBehaviour
{
    [SerializeField] List <TMP_InputField> ips;
    public void ClearKeHoach(){
        foreach (TMP_InputField ip in ips){
            ip.text = "";
        }
    }
}
