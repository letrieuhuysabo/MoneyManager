using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
[System.Serializable]
public class BienDong : ICloneable
{

    [SerializeField] string soTien;
    [SerializeField] string chuThich;
    [SerializeField] string thoiGian;
    public BienDong(string soTien, string chuThich){
        this.soTien = soTien;
        this.chuThich = chuThich;
        if (chuThich == ""){
            // Debug.Log(chuThich);
            chuThich = "Khong co chu thich";
            // Debug.Log(chuThich);
        }
        thoiGian = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
    }
    public BienDong(string soTien, string chuThich, string thoiGian){
        this.soTien = soTien;
        this.chuThich = chuThich;
        if (chuThich == ""){
            // Debug.Log(chuThich);
            chuThich = "Khong co chu thich";
            // Debug.Log(chuThich);
        }
        this.thoiGian = thoiGian;
    }
    public BienDong(BienDong other)
    {
        this.soTien = new string(other.soTien);
        this.chuThich = new string(other.chuThich);
        this.thoiGian = new string(other.thoiGian);
    }
    public string getSoTien()
    {
        return soTien;
    }
    public string getChuThich()
    {
        return chuThich;
    }
    public string getThoiGian()
    {
        return thoiGian;
    }
    public void setSoTien(string m){
        this.soTien = m;
    }
    public void setChuThich(string c){
        this.chuThich = c;
    }

    public object Clone()
    {
        return new BienDong(this);
    }
}
