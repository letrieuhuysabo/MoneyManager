using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
public class CapNhatTien : MonoBehaviour
{
    [SerializeField] TMP_InputField oNhapTien, chuThich;
    [SerializeField] Toggle oTruTien;
    [SerializeField] GameObject panelXacNhan, panelHoi, Menu;
    Animator anim;
    public static CapNhatTien instance;
    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }
    void OnEnable()
    {
        string tmp = Menu.transform.Find("Money").Find("SoDuPanel").Find("Money").GetComponent<TextMeshProUGUI>().text;
        // tongSoTien = int.Parse(tmp.Replace(".","").Replace(" đ",""));
        ResetInputs();
    }
    void ResetInputs()
    {
        oNhapTien.text = "";
        oTruTien.isOn = false;
        chuThich.text = "";
    }
    public void thoat()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void xacnhan1()
    {
        if (oNhapTien.text == "")
        { // nếu chưa nhập tiền ko tiếp tục
            ThongBaoPanel.instance.showThongBao("Hãy nhập số tiền");
            return;
        }
        if (oTruTien.isOn)
        { // hỏi xem trừ tiền vào phân loại nào
            panelHoi.SetActive(true);
            ChangeAnim("MoPanelTruTien");
        }
        else
        {
            panelXacNhan.SetActive(true);
            ChangeAnim("MoConfirmPanel");
        }

    }
    public void huyxacnhan2()
    {
        
        DongConfirmPanel(0.5f);
    }
    public void xacNhan2(GameObject b)
    {
        //
        LichSuBienDong.instance.luuLichSu(b);
        // panelXacNhan.SetActive(false);
        ResetInputs();
        ThongBaoPanel.instance.showThongBao("Đã cập nhật số dư");
        
        DongConfirmPanel(0.5f);

    }
    public void xacNhanTruTien(GameObject b)
    {
        //
        LichSuBienDong.instance.luuLichSu(b);
        // panelXacNhan.SetActive(false);
        ResetInputs();
        ThongBaoPanel.instance.showThongBao("Đã cập nhật số dư");
    }
    public void ChangeAnim(string s)
    {
        anim.SetTrigger(s);
    }
    async void DongConfirmPanel(float duration)
    {
        ChangeAnim("DongConfirmPanel");
        await Task.Delay((int)(duration * 1000));
        panelXacNhan.SetActive(false);
    }
}
