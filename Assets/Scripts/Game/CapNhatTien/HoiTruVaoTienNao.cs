using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class HoiTruVaoTienNao : MonoBehaviour
{
    List<PhanLoai> ds;
    [SerializeField] TextMeshProUGUI tongSoTienMenu;
    [SerializeField] Transform container;
    [SerializeField] TMP_InputField soTienTru;
    [SerializeField] GameObject confirmButton;
    List<GameObject> phanloaisGameObj;
    string moneyNeedChange, nameNeedChange;
    void Awake()
    {
        phanloaisGameObj = new List<GameObject>();
    }
    void OnEnable()
    {
        GameObject phanLoaiPrefab = container.GetChild(0).gameObject;
        int tongTien;
        try
        {
            tongTien = SaveAndLoadSystem.Load().money;
        }
        catch (NullReferenceException)
        {
            tongTien = 0;
        }
        DataPhanLoai dt = SaveAndLoadSystem.LoadPhanLoai();
        if (dt != null)
        {
            ds = dt.ds;


            for (int i = 0; i < ds.Count; i++)
            {
                GameObject phanLoai = Instantiate(phanLoaiPrefab);
                phanloaisGameObj.Add(phanLoai);
                phanLoai.transform.SetParent(phanLoaiPrefab.transform.parent, false);
                phanLoai.transform.Find("Tien").GetComponent<TextMeshProUGUI>().text = ds[i].soTien;
                tongTien -= int.Parse(ds[i].soTien);
                phanLoai.transform.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = ds[i].tenPhanLoai;
                phanLoai.transform.Find("ChuThich").Find("HideText").gameObject.SetActive(true);
            }
        }
        phanLoaiPrefab.transform.Find("Tien").GetComponent<TextMeshProUGUI>().text = FormatMoney(tongTien + "");
        phanLoaiPrefab.transform.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = "So tien tu do";
    }
    string FormatMoney(string n)
    {
        string s = "";
        int dem = 0;
        for (int i = n.Length - 1; i >= 0; i--)
        {
            s = n[i] + s;
            dem++;
            if (i > 0 && dem == 3)
            {
                dem = 0;
                s = "." + s;
            }
        }


        return s;
    }
    void OnDisable()
    {
        foreach (GameObject phanLoai in phanloaisGameObj)
        {
            Destroy(phanLoai);
        }
        phanloaisGameObj.Clear();
        if (confirmButton != null)
            confirmButton.SetActive(false);
    }
    public void DongPanel()
    {
        CapNhatTien.instance.ChangeAnim("DongPanelTruTien");
        Invoke("Dong", 0.5f);
    }
    void Dong()
    {
        gameObject.SetActive(false);
    }
    public void kiemTraCoDuTienKhong(Transform tf)
    {

        int soTienNhap = int.Parse(soTienTru.text);
        string tmp = tf.Find("Tien").GetComponent<TextMeshProUGUI>().text.Replace(".", "").Replace(" đ", "");
        int soTienCoSan = int.Parse(tmp);
        if (soTienCoSan < soTienNhap)
        { // nếu ko đủ
            ThongBaoPanel.instance.showThongBao("Phân loại này không đủ tiền");
            if (confirmButton != null)
                confirmButton.SetActive(false);
            return;
        }
        // nếu đủ
        moneyNeedChange = tmp;
        nameNeedChange = tf.Find("ChuThich").GetComponent<TextMeshProUGUI>().text;
        if (confirmButton != null)
            confirmButton.SetActive(false);
        confirmButton = tf.Find("ConfirmButton").gameObject;
        confirmButton.SetActive(true);
    }
    public void truVaoPhanLoai(Transform tf)
    {

        foreach (PhanLoai pl in ds)
        {
            if (pl.tenPhanLoai == nameNeedChange)
            {
                pl.soTien = (int.Parse(pl.soTien) - int.Parse(soTienTru.text)) + "";
                pl.capNhatLanCuoi = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                break;
            }
        }
        DongPanel();
        DataPhanLoai dataPhanLoai = new DataPhanLoai(ds);
        SaveAndLoadSystem.SavePhanLoai(dataPhanLoai);
        CapNhatTien.instance.xacNhanTruTien(transform.parent.Find("Panel").gameObject);
    }
    
}
