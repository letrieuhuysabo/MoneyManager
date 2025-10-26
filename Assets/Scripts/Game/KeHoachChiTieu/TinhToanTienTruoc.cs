using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TinhToanTienTruoc : MonoBehaviour
{
    [SerializeField] GameObject panelTinhToan;
    [SerializeField] Transform cacThuTrongTuan;
    [SerializeField] TextMeshProUGUI thongTin;
    public void MoPanelTinhToan()
    {
        panelTinhToan.SetActive(true);
        TinhToan();
    }
    public void DongPanelTinhToan()
    {

        panelTinhToan.GetComponent<Animator>().SetTrigger("BienMat");
        Invoke("Dong", 0.5f);
    }
    void Dong()
    {
        panelTinhToan.SetActive(false);
    }
    void TinhToan()
    {
        // lấy thông tin chi tiêu vào các ngày trong tuần
        int[] tongTienSeChiTrongNgay = new int[7];
        for (int i = 0; i < cacThuTrongTuan.childCount; i++)
        {
            // Lấy text
            string s = cacThuTrongTuan.GetChild(i).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text;
            // lấy độ dài con số
            int doDaiSo = s.LastIndexOf("<") - s.IndexOf(">") - 2;

            // cắt text
            s = s.Substring(s.IndexOf(">") + 2, doDaiSo);

            tongTienSeChiTrongNgay[i] += int.Parse(s) * 1000;
            // Debug.Log(tongTienSeChiTrongNgay[i]);
        }
        // Lấy thông tin ngày hôm nay để tính toán
        DateTime now = DateTime.Now;
        // biến cờ để chọn điểm bắt đầu cho mảng
        int flag = 0;
        if (now.DayOfWeek.ToString() == "Monday")
        {
            flag = 1;
        }
        else if (now.DayOfWeek.ToString() == "Tuesday")
        {
            flag = 2;
        }
        else if (now.DayOfWeek.ToString() == "Wednesday")
        {
            flag = 3;
        }
        else if (now.DayOfWeek.ToString() == "Thursday")
        {
            flag = 4;
        }
        else if (now.DayOfWeek.ToString() == "Friday")
        {
            flag = 5;
        }
        else if (now.DayOfWeek.ToString() == "Saturday")
        {
            flag = 6;
        }
        else
        {
            flag = 7;
        }

        // Lấy thông tin
        int tongSoTien;
        try
        {
            tongSoTien = SaveAndLoadSystem.Load().money;
        }
        catch (NullReferenceException)
        {
            tongSoTien = 0;
        }
        int soTienTuDo = tongSoTien;
        List<PhanLoai> ds;
        try
        {
            DataPhanLoai dt = SaveAndLoadSystem.LoadPhanLoai();
            ds = dt.ds;
        }
        catch (NullReferenceException)
        {
            ds = new List<PhanLoai>();
        }

        foreach (PhanLoai pl in ds)
        {
            soTienTuDo -= int.Parse(pl.soTien);
        }
        // Tính toán
        for (int i = flag; i < 7; i++)
        {
            tongSoTien -= tongTienSeChiTrongNgay[i];
            soTienTuDo -= tongTienSeChiTrongNgay[i];
        }
        string textSeHien = "Theo kế hoạch, số tiền của bạn vào cuối tuần sẽ là\n"
                                + FormatMoney(tongSoTien) + "\n"
                                + "(" + FormatMoney(soTienTuDo) + ")";
        thongTin.text = textSeHien;

    }
    string FormatMoney(int money)
    {
        string s = money + "";
        string s1 = "";
        int tmp = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (tmp == 3)
            {
                s1 = "." + s1;
                i++;
                tmp = 0;
                continue;
            }
            else
            {
                s1 = s[i] + s1;
                tmp++;
            }
        }
        return s1 + " đ";
    }
}
