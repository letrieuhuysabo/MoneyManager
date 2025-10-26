using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChenhLechChiTieu : MonoBehaviour
{
    TMP_InputField keHoach, thucTe;
    TextMeshProUGUI tittleThu;
    // Start is called before the first frame update
    void Start()
    {
        tittleThu = transform.Find("TittleThu").Find("ChenhLechChiTieu").GetComponent<TextMeshProUGUI>();
        keHoach = transform.Find("KeHoach").Find("InputField (TMP)").GetComponent<TMP_InputField>();
        thucTe = transform.Find("ThucTe").Find("InputField (TMP)").GetComponent<TMP_InputField>();
    }
    public void capNhatChenhLech()
    {
        StartCoroutine(CapNhatChenhLechCoroutine());
    }
    IEnumerator CapNhatChenhLechCoroutine(){
        yield return null;
        List<string> chiTieuKeHoach = new List<string>();
        List<string> chiTieuThucTe = new List<string>();
        string []tmp = keHoach.text.Split('\n');
        foreach (string t in tmp)
        {
            chiTieuKeHoach.Add(t);
        }
        tmp = thucTe.text.Split('\n');
        foreach (string t in tmp)
        {
            chiTieuThucTe.Add(t);
        }
        List<int> chiTieuKeHoachInt = new List<int>();
        foreach (string t in chiTieuKeHoach)
        {
            try
            {
                chiTieuKeHoachInt.Add(int.Parse(t.Substring(t.LastIndexOf(" ") + 1)));
            }
            catch (Exception) { }
        }
        List<int> chiTieuThucTeInt = new List<int>();
        foreach (string t in chiTieuThucTe)
        {
            try
            {
                chiTieuThucTeInt.Add(int.Parse(t.Substring(t.LastIndexOf(" ") + 1)));
            }
            catch (Exception) { }
        }
        int tongChiTieuKeHoach = 0;
        foreach (int t in chiTieuKeHoachInt){
            tongChiTieuKeHoach += t;
        }
        int tongChiTieuThucTe = 0;
        foreach (int t in chiTieuThucTeInt){
            tongChiTieuThucTe += t;
        }
        int chenhLechChiTieu = tongChiTieuKeHoach - tongChiTieuThucTe;
        if (chenhLechChiTieu < 0){
            tittleThu.text = "<color=#FF3000>" + chenhLechChiTieu + "</color>";
        }
        else {
            tittleThu.text = "<color=#00FF18>+" + chenhLechChiTieu + "</color>";
        }
    }
}
