using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading.Tasks;
public class EditPhanLoaiPanel : MonoBehaviour
{
    [SerializeField] Transform oldInfo, newInfo;
    [SerializeField] TextMeshProUGUI tienTuDo;
    async void OnEnable()
    {
        // reset inputs
        newInfo.Find("SoTien").GetComponent<TMP_InputField>().text = newInfo.Find("ChuThich").GetComponent<TMP_InputField>().text = "";
        await Task.Delay(100);
        // tắt tính năng chỉnh sửa tên phân loại nếu là dự trù hoặc mạo hiểm
        string tenChuThich = oldInfo.Find("ChuThich").GetComponent<TextMeshProUGUI>().text;
        TMP_InputField newChuThich = newInfo.Find("ChuThich").GetComponent<TMP_InputField>();
        if (tenChuThich == "dự trù" || tenChuThich == "mạo hiểm")
        {
            newChuThich.text = tenChuThich;
            newChuThich.enabled = false;
        }
        else
        {
            newChuThich.enabled = true;
        }
    }
    public void loadData(Transform pl)
    {
        // load Data cho oldInfo
        oldInfo.Find("SoTien").GetComponent<TextMeshProUGUI>().text = pl.Find("SoTien").GetComponent<TextMeshProUGUI>().text;
        oldInfo.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = pl.Find("ChuThich").GetComponent<TextMeshProUGUI>().text;
    }
    public void copyData()
    {
        string tmp = oldInfo.Find("SoTien").GetComponent<TextMeshProUGUI>().text.Replace(".", "").Replace(" đ", "");
        newInfo.Find("SoTien").GetComponent<TMP_InputField>().text = tmp;
        newInfo.Find("ChuThich").GetComponent<TMP_InputField>().text = oldInfo.Find("ChuThich").GetComponent<TextMeshProUGUI>().text;
    }
    async public void close()
    {
        PhanLoaiTien.instance.ChangeAnim("DongEditPhanLoaiPanel");
        await Task.Delay(500);
        gameObject.SetActive(false);
    }
    public void confirm()
    {
        // ktra xem có nhập tiền hay chưa
        if (newInfo.Find("SoTien").GetComponent<TMP_InputField>().text == "")
        {
            ThongBaoPanel.instance.showThongBao("Hãy nhập số tiền");
            return;
        }
        // ktra xem có đủ tiền hay ko
        int tienTD = int.Parse(tienTuDo.text.Replace(".", "").Replace(" đ", ""));
        tienTD += int.Parse(oldInfo.Find("SoTien").GetComponent<TextMeshProUGUI>().text.Replace(".", "").Replace(" đ", ""));
        if (int.Parse(newInfo.Find("SoTien").GetComponent<TMP_InputField>().text) > tienTD)
        {
            ThongBaoPanel.instance.showThongBao("Không đủ số tiền tự do, tối đa " + tienTD);
            return;
        }
        List<PhanLoai> phanLoais = PhanLoaiTien.instance.getList();
        foreach (PhanLoai pl in phanLoais)
        {
            if (pl.tenPhanLoai == oldInfo.Find("ChuThich").GetComponent<TextMeshProUGUI>().text)
            {
                pl.tenPhanLoai = newInfo.Find("ChuThich").GetComponent<TMP_InputField>().text;
                pl.soTien = newInfo.Find("SoTien").GetComponent<TMP_InputField>().text;
                pl.capNhatLanCuoi = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                ThongBaoPanel.instance.showThongBao("Đã chỉnh sửa phân loại");
                break;
            }
        }
        DataPhanLoai dataPhanLoai = new DataPhanLoai(phanLoais);
        SaveAndLoadSystem.SavePhanLoai(dataPhanLoai);
        PhanLoaiTien.instance.loadData();
        close();
    }
}
