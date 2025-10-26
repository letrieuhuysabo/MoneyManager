using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class LichSuBienDong : MonoBehaviour
{

    List<BienDong> lichSuBienDong;
    int money;
    public static LichSuBienDong instance;
    public LichSuBienDong(List <BienDong> b, int m){
        this.lichSuBienDong = b;
        this.money = m;
    }
    void Awake()
    {
        instance = this;
        lichSuBienDong = new List<BienDong>();
        Load();
        // Debug.Log(lichSuBienDong[0].getSoTien());
    }
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        // Debug.Log(lichSuBienDong[0].getThoiGian());
    }
    public void setMoney(int m)
    {
        money = m;
        SaveAndLoadSystem.Save(this);
    }
    public void editBienDong(string thoiGian, string soTienMoi, string chuThichMoi){
        foreach (BienDong b in lichSuBienDong){
            if (b.getThoiGian() == thoiGian){
                b.setSoTien(soTienMoi);
                b.setChuThich(chuThichMoi);
                SaveAndLoadSystem.Save(this);
                return;
            }
        }
    }
    
    // void Update()
    // {
    //     Debug.Log(lichSuBienDong.Count);
    // }
    public List<BienDong> getListBienDong()
    {
        return lichSuBienDong;
    }
    public void setListBienDong(List <BienDong> lbd){
        lichSuBienDong = lbd;
        SaveAndLoadSystem.Save(this);
    }
    public int getMoney()
    {
        return money;
    }
    public void luuLichSu(GameObject b)
    {
        int m;
        try
        {
            m = int.Parse(b.transform.Find("InputField (TMP)").GetComponent<TMP_InputField>().text);
        }
        catch (OverflowException)
        {
            ThongBaoPanel.instance.showThongBao("Số quá lớn, hãy nhập số nhỏ hơn");
            return;
        }
        // Debug.Log(m);
        bool check = b.transform.Find("GiamTien").GetComponent<Toggle>().isOn;
        BienDong bd;
        if (check)
        {
            money -= m;
            bd = new BienDong("-" + m, b.transform.Find("ChuThich").GetComponent<TMP_InputField>().text);
        }
        else
        {
            money += m;
            bd = new BienDong("+" + m, b.transform.Find("ChuThich").GetComponent<TMP_InputField>().text);
        }
        lichSuBienDong.Add(bd);
        // SaveAndLoadSystem.SaveBienDong(this);
        // SaveAndLoadSystem.SaveTien(this);

        // //
        // money = 0;
        // lichSuBienDong.Clear();
        // //

        SaveAndLoadSystem.Save(this);

    }
    public void Load()
    {
        // money = SaveAndLoadSystem.LoadTien();
        // // Bien Dong
        // lichSuBienDong = SaveAndLoadSystem.LoadBienDong();
        // if (lichSuBienDong == null){
        //     Debug.Log("hello");
        //     lichSuBienDong = new List<BienDong>();
        // }
        DataNeedSaved dt = SaveAndLoadSystem.Load();
        if (dt != null)
        {
            // Debug.Log("hello1");
            this.lichSuBienDong = dt.getLichSuBienDong();
            if (lichSuBienDong == null){
                lichSuBienDong = new List<BienDong>();
            }
            this.money = dt.getMoney();
        }
        else
        {
            Debug.Log("hello");
        }
    }
}
