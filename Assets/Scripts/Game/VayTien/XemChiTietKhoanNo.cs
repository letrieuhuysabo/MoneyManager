using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class XemChiTietKhoanNo : MonoBehaviour
{
    [SerializeField] GameObject thongTinPanel, thongTinPrefab;
    [SerializeField] TextMeshProUGUI tongTienNo;
    List<GameObject> thongTins;
    void Awake()
    {
        thongTins = new();
    }
    public void ShowThongTinKhoanVay()
    {
        ThongTinKhoanVay thongTinKhoanVay = SaveAndLoadSystem.LoadThongTinKhoanVay();
        thongTinPanel.SetActive(true);
        // xóa các thông tin cũ
        foreach (GameObject obj in thongTins)
        {
            Destroy(obj);
        }
        thongTins.Clear();
        // hiện tiền vay ban đầu, tiền lãi, tổng nợ
        KhoanVay kv = SaveAndLoadSystem.LoadKhoanVay();
        GameObject tienVayBanDau = taoThongTin();
        tienVayBanDau.GetComponent<TextMeshProUGUI>().text = "Tiền vay gốc: " + kv.tienVay;
        GameObject tienLai = taoThongTin();
        tienLai.GetComponent<TextMeshProUGUI>().text = "Tiền lãi: " + kv.tienLai;
        tongTienNo.text = "Tổng nợ:\n" + Configs.formatMoney(Configs.ConvertTienToInt(kv.tienVay) + Configs.ConvertTienToInt(kv.tienLai) + "");
        // hiện các thông tin khác
        for (int i = 0; i < thongTinKhoanVay.notes.Count - 1; i++)
        {
            GameObject thongTin = taoThongTin();
            thongTin.GetComponent<TextMeshProUGUI>().text = thongTinKhoanVay.notes[i];
            
        }
    }
    GameObject taoThongTin()
    {
        GameObject gObj = Instantiate(thongTinPrefab);
        gObj.transform.SetParent(thongTinPrefab.transform.parent, false);
        gObj.SetActive(true);
        thongTins.Add(gObj);
        return gObj;
    }
    public void CloseThongTin()
    {
        thongTinPanel.SetActive(false);
    }
}
