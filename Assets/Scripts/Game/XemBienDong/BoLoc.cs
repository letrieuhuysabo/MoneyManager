using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class BoLoc : MonoBehaviour
{
    [SerializeField] TMP_Dropdown locLoaiBienDongDropdown, locThoiGianDropdown;
    [SerializeField] TMP_InputField locChuThichInput;
    [SerializeField] Transform danhSachBienDong;
    void OnEnable(){
        loc();
    }
    public bool locLoaiBienDong(Transform bienDong){
        if (locLoaiBienDongDropdown.value == 0){ // loc tat ca
            return true;
        }
        else {
            if ((bienDong.Find("SoTien").GetComponent<TextMeshProUGUI>().text[0] == '+' && locLoaiBienDongDropdown.value == 1) || 
                ((bienDong.Find("SoTien").GetComponent<TextMeshProUGUI>().text[0] == '-' && locLoaiBienDongDropdown.value == 2))){
                return true;
            }
            else {
                return false;
            }
                
        }
    }
    public bool locThoiGian(Transform bienDong){
        if (locThoiGianDropdown.value == 0){ // loc tat ca
            return true;
        }
        else {
            DateTime bienDongTime = DateTime.ParseExact(bienDong.Find("ThoiGian").GetComponent<TextMeshProUGUI>().text.Substring(0,10), "dd-MM-yyyy", null);
            bienDongTime = new DateTime(bienDongTime.Year,bienDongTime.Month,bienDongTime.Day);
            DateTime now = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            // Debug.Log(bienDongTime);
            if (locThoiGianDropdown.value == 1){ // lay hom nay
                if (DateTime.Compare(bienDongTime,now) == 0){
                    return true;
                }
            }
            else if (locThoiGianDropdown.value == 2){ // 3 ngay gan nhat
                if (DateTime.Compare(bienDongTime.AddDays(2),now) >= 0){
                    return true;
                }
            }
            else if (locThoiGianDropdown.value == 3){ // 7 ngay gan nhat
                if (DateTime.Compare(bienDongTime.AddDays(6),now) >= 0){
                    return true;
                }
            }
            else { // 30 ngay gan nhat
                if (DateTime.Compare(bienDongTime.AddDays(29),now) >= 0){
                    return true;
                }
            }
            return false;
        }
        
    }
    public bool locChuThich(Transform bienDong){
        if (locChuThichInput.text==""){
            return true;
        }
        if (bienDong.Find("ChuThich").GetComponent<TextMeshProUGUI>().text.Contains(locChuThichInput.text)){
            bienDong.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = highlightString(bienDong.Find("ChuThich").GetComponent<TextMeshProUGUI>(),locChuThichInput.text);
            // bienDong.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = "abc";
            return true;
        }
        else {
            // bienDong.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = unhighlightString(bienDong.Find("ChuThich").GetComponent<TextMeshProUGUI>(),locChuThichInput.text);
            return false;
        }
    }
    public void loc(){
        for (int i=1;i<danhSachBienDong.childCount;i++){
            Transform bienDong = danhSachBienDong.GetChild(i);
            if (locLoaiBienDong(bienDong) && locThoiGian(bienDong) && locChuThich(bienDong)) {
                bienDong.gameObject.SetActive(true);
            }
            else {
                bienDong.gameObject.SetActive(false);
            }
        }
    }
    string highlightString(TextMeshProUGUI originalString, string stringNeedHighLight){
        string s = originalString.text;
        s = s.Replace(stringNeedHighLight,"<color=#E4DD4C>" + stringNeedHighLight + "</color>");
        return s;
    }
    string unhighlightString(TextMeshProUGUI originalString, string stringNeedUnHighLight){
        string s = originalString.text;
        // s = s.Replace("pro" + stringNeedUnHighLight+ "pro", stringNeedUnHighLight);
        return s;
    }
}
