using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
public class AutoAddMoneyPanel : MonoBehaviour
{
    TextMeshProUGUI chuThichText, soTienTangText;
    Transform phanLoaiDangThaoTac;
    void Awake()
    {
        chuThichText = transform.Find("Panel").Find("ChuThich").GetComponent<TextMeshProUGUI>();
        soTienTangText = transform.Find("Panel").Find("SoTienThemVao").GetComponent<TextMeshProUGUI>();
    }
    public void LoadText(string chuThich, int soTien)
    {
        chuThichText.text = chuThich;
        soTienTangText.text = "+ " + soTien;

    }
    public void SetPhanLoaiDangThaoTac(Transform phanLoaiDangThaoT)
    {
        this.phanLoaiDangThaoTac = phanLoaiDangThaoT;
    }
    public void AutoAddMoneyIntoPhanLoai()
    {
        Transform pl = phanLoaiDangThaoTac;
        string chuThich = pl.Find("ChuThich").GetComponent<TextMeshProUGUI>().text;
        int moneyNeedToAdd = int.Parse(chuThich.Substring(chuThich.LastIndexOf("/") + 1));
        TextMeshProUGUI soTienText = pl.Find("SoTien").GetComponent<TextMeshProUGUI>();
        int soTien = int.Parse(soTienText.text.Replace(".", "").Replace(" đ", "")) + moneyNeedToAdd;
        List<PhanLoai> ds = PhanLoaiTien.instance.getList();
        foreach (PhanLoai p in ds)
        {
            if (p.tenPhanLoai == chuThich)
            {
                p.soTien = soTien + "";
                p.capNhatLanCuoi = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                break;
            }
        }
        DataPhanLoai dt = new DataPhanLoai(ds);
        SaveAndLoadSystem.SavePhanLoai(dt);
        PhanLoaiTien.instance.loadData();
        ThongBaoPanel.instance.showThongBao("Đã cập nhật thành công");
        PhanLoaiTien.instance.CloseAutoAddMoneyPanel();
    }
}
