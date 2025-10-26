using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VayTienMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu, traNoButton, vayNoButton, warningDate, xemChiTietKhoanNo;
    [SerializeField] TextMeshProUGUI tongNoText, ngayNoText;
    [SerializeField] GameObject vayPanel, traPanel;
    public static VayTienMenu instance;
    void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        ShowInfos();
    }
    public void ShowInfos()
    {
        KhoanVay khoanVay = SaveAndLoadSystem.LoadKhoanVay();
        warningDate.SetActive(false);
        if (khoanVay == null) // ko có vay, ko có nợ
        {
            HienThongTinKhongCoNo();
        }
        else
        {
            HienThongTin(khoanVay);
        }
    }
    public void ExitToMenu()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void HienThongTin(KhoanVay khoanVay)
    {
        int tongNo = Configs.ConvertTienToInt(khoanVay.tienVay) + Configs.ConvertTienToInt(khoanVay.tienLai);
        warningDate.SetActive(false);
        if (tongNo == 0) // ko có nợ
        {
            HienThongTinKhongCoNo();

        }
        else // có nợ
        {
            DateTime date = Configs.ConvertToDateTime(khoanVay.ngayHetHan);
            DateTime currentDate = DateTime.Now;
            // Debug.Log(date.ToString("dd-MM-yyyy"));
            // Debug.Log(currentDate.ToString("dd-MM-yyyy"));
            // Debug.Log(khoanVay.ngayHetHan);
            // Muộn hẹn, tăng tiền lãi
            // if (currentDate >= date)
            // {
            //     // tăng tiền lãi
            //     int tienCongThem = (int)(tongNo * 0.2f);
            //     int tienLaiMoi = Configs.ConvertTienToInt(khoanVay.tienLai) + tienCongThem;
            //     khoanVay.tienLai = Configs.formatMoney(tienLaiMoi + "");
            //     string ngayTraCu = khoanVay.ngayHetHan;
            //     string ngayTraMoi = Configs.ConvertToDateTime(ngayTraCu).AddMonths(1).ToString("dd-MM-yyyy");
            //     khoanVay.ngayHetHan = ngayTraMoi;
            //     SaveAndLoadSystem.SaveKhoanVay(khoanVay);
            //     //
            //     tongNo = Configs.ConvertTienToInt(khoanVay.tienVay) + Configs.ConvertTienToInt(khoanVay.tienLai);
            //     // Lưu thông tin chi tiết
            //     ThongTinKhoanVay thongTinKhoanVay = SaveAndLoadSystem.LoadThongTinKhoanVay();
            //     thongTinKhoanVay.notes.RemoveAt(thongTinKhoanVay.notes.Count - 1); // xóa tổng nợ
            //     thongTinKhoanVay.notes.Add("Trả trễ hẹn: " + ngayTraCu + " tăng nợ " + Configs.formatMoney(tienCongThem + "") + " (đã cộng vào lãi nêu trên)");
            //     int tienVay = Configs.ConvertTienToInt(khoanVay.tienVay);
            //     thongTinKhoanVay.notes.Add(Configs.formatMoney(tienVay + tienLaiMoi + ""));
            //     SaveAndLoadSystem.SaveThongTinKhoanVay(thongTinKhoanVay);
            // }
            // // Cảnh báo gần hết hạn nợ
            // else if (currentDate.AddDays(7) >= date)
            // {
            //     warningDate.SetActive(true);
            // }
            tongNoText.text = Configs.formatMoney(tongNo + "");
            ngayNoText.gameObject.SetActive(true);
            xemChiTietKhoanNo.SetActive(true);
            ngayNoText.text = khoanVay.ngayHetHan;
            vayNoButton.SetActive(false);
            traNoButton.SetActive(true);
            
            

        }
        // DateTime currentDate = DateTime.Now;
        // dateText.text = currentDate.ToString("dd-MM-yyyy");
    }
    void HienThongTinKhongCoNo()
    {
        
        tongNoText.text = "0 đ";
        ngayNoText.gameObject.SetActive(false);
        xemChiTietKhoanNo.SetActive(false);
        vayNoButton.SetActive(true);
        traNoButton.SetActive(false);
    }
    public void MoPanelVayTien()
    {
        vayPanel.SetActive(true);
    }
    public void MoPanelTraTien()
    {
        traPanel.SetActive(true);
    }
}
