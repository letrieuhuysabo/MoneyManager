using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VayPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI khoanVayToiDa;
    [SerializeField] TMP_InputField soTienVay;
    [SerializeField] GameObject confirmPanel;
    private void OnEnable()
    {
        int tienDuTru = Configs.GetTienDuTru();
        khoanVayToiDa.text = "Tối đa: (tiền dự trù) " + Configs.formatMoney(tienDuTru + "");
    }
    
    
    public void moConfirmPanel()
    {
        int tienVay = int.Parse(soTienVay.text);
        int tienDuTru = Configs.GetTienDuTru();
        if (tienVay > tienDuTru)
        {
            ThongBaoPanel.instance.showThongBao("Số tiền vay quá lớn, hãy thử lại");
            return;
        }
        else if (tienVay % 1000 != 0)
        {
            ThongBaoPanel.instance.showThongBao("Số tiền vay phải chia hết cho 1.000");
            return;
        }
        confirmPanel.SetActive(true);
        confirmPanel.transform.Find("SoTienVay").GetComponent<TextMeshProUGUI>().text = Configs.formatMoney(soTienVay.text);
        confirmPanel.transform.Find("SoTienPhaiTra").GetComponent<TextMeshProUGUI>().text = Configs.formatMoney((int.Parse(soTienVay.text) * 1.2f) + "");
        confirmPanel.transform.Find("Date").GetComponent<TextMeshProUGUI>().text = DateTime.Now.AddMonths(1).ToString("dd-MM-yyyy");
    }
    public void dongConfirmPanel()
    {
        confirmPanel.SetActive(false);
    }
    public void Dong()
    {
        VayTienMenu.instance.ShowInfos();
        gameObject.SetActive(false);
    }
    public void confirm()
    {
        DataPhanLoai dataPhanLoai = SaveAndLoadSystem.LoadPhanLoai();
        List<PhanLoai> pls = dataPhanLoai.ds;
        for (int i = 0; i < pls.Count; i++)
        {
            if (pls[i].tenPhanLoai == "dự trù")
            {
                int tmp = Configs.ConvertTienToInt(pls[i].soTien);
                tmp -= int.Parse(soTienVay.text);
                pls[i].soTien = tmp + "";
                break;
            }
        }
        // lưu khoản vay
        int tienVay = Configs.ConvertTienToInt(confirmPanel.transform.Find("SoTienVay").GetComponent<TextMeshProUGUI>().text);
        int tienLai = Configs.ConvertTienToInt(confirmPanel.transform.Find("SoTienPhaiTra").GetComponent<TextMeshProUGUI>().text) - tienVay;
        string date = confirmPanel.transform.Find("Date").GetComponent<TextMeshProUGUI>().text;
        KhoanVay khoanVay = new KhoanVay(Configs.formatMoney(tienVay + ""), Configs.formatMoney(tienLai + ""), date);
        SaveAndLoadSystem.SaveKhoanVay(khoanVay);
        // lưu phân loại
        DataPhanLoai dt = new DataPhanLoai(pls);
        SaveAndLoadSystem.SavePhanLoai(dt);
        // thông báo
        ThongBaoPanel.instance.showThongBao("Vay thành công");
        // lưu thông tin khoản vay
        ThongTinKhoanVay thongTinKhoanVay = new();
        thongTinKhoanVay.notes.Add("Ngày vay: " + date);
        SaveAndLoadSystem.SaveThongTinKhoanVay(thongTinKhoanVay);
        dongConfirmPanel();
        Dong();
    }
}
