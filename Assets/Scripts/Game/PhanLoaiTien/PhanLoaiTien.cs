using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
public class PhanLoaiTien : MonoBehaviour
{

    [SerializeField] GameObject Menu, loaiPrefab, themPanel, editPanel, deletePanel, autoAddMoneyPanel, tienDuTru, tienMaoHiem;
    [SerializeField] TextMeshProUGUI tongSoTien;
    List<PhanLoai> ds;
    List<GameObject> clearDs;
    public static PhanLoaiTien instance;
    Animator anim;
    void Awake()
    {
        instance = this;
        ds = new List<PhanLoai>();
        clearDs = new List<GameObject>();

    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void exit()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        loadData();
    }
    public void loadData()
    {
        // Debug.Log(ds);
        DataPhanLoai dt = SaveAndLoadSystem.LoadPhanLoai();
        if (dt != null)
        {
            ds = dt.ds;
        }
        // Debug.Log(ds);
        // return;
        // hiển thị tổng số tiền
        // Debug.Log(Menu.transform.Find("Money").Find("SoDuPanel").Find("Money").GetComponent<TextMeshProUGUI>().text);
        tongSoTien.text = Menu.transform.Find("Money").Find("SoDuPanel").Find("Money").GetComponent<TextMeshProUGUI>().text;
        string tmp = tongSoTien.text.Replace(".", "").Replace(" đ", "");
        // tổng số tiền
        int sumTien = int.Parse(tmp);
        // Debug.Log(tmp);
        // hiển thị các phân loại
        Debug.Log(clearDs.Count);
        for (int i = 0; i < clearDs.Count; i++)
        {
            if (clearDs[i] != null)
            {
                Destroy(clearDs[i]);
            }
        }
        clearDs.Clear();
        for (int i = 0; i < ds.Count; i++)
        {
            // tiền dự trù
            if (ds[i].tenPhanLoai == "dự trù")
            {
                GameObject loai = tienDuTru;
                loai.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().text = Configs.formatMoney(ds[i].soTien + "");
                loai.transform.Find("Edit").gameObject.SetActive(true);
                loai.transform.Find("CapNhatLanCuoi").gameObject.SetActive(true);
                loai.transform.Find("CapNhatLanCuoi").GetComponent<TextMeshProUGUI>().text = "Cập nhật lần cuối:\n" + ds[i].capNhatLanCuoi;
                loai.transform.Find("ChuThich").Find("HideText").gameObject.SetActive(true);
                sumTien -= int.Parse(ds[i].soTien);
            }
            // tiền mạo hiểm
            else if (ds[i].tenPhanLoai == "mạo hiểm")
            {
                GameObject loai = tienMaoHiem;
                loai.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().text = Configs.formatMoney(ds[i].soTien + "");
                loai.transform.Find("Edit").gameObject.SetActive(true);
                loai.transform.Find("CapNhatLanCuoi").gameObject.SetActive(true);
                loai.transform.Find("CapNhatLanCuoi").GetComponent<TextMeshProUGUI>().text = "Cập nhật lần cuối:\n" + ds[i].capNhatLanCuoi;
                loai.transform.Find("ChuThich").Find("HideText").gameObject.SetActive(true);
                sumTien -= int.Parse(ds[i].soTien);
            }
            // các loại tiền còn lại
            else
            {
                GameObject loai = Instantiate(loaiPrefab);
                clearDs.Add(loai);
                loai.transform.SetParent(loaiPrefab.transform.parent, false);
                loai.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().text = Configs.formatMoney(ds[i].soTien) + "";
                loai.transform.Find("Delete").gameObject.SetActive(true);
                loai.transform.Find("AutoAddMoney").gameObject.SetActive(true);
                loai.transform.Find("Edit").gameObject.SetActive(true);
                loai.transform.Find("CapNhatLanCuoi").gameObject.SetActive(true);
                loai.transform.Find("CapNhatLanCuoi").GetComponent<TextMeshProUGUI>().text = "Cập nhật lần cuối:\n" + ds[i].capNhatLanCuoi;
                loai.transform.Find("ChuThich").Find("HideText").gameObject.SetActive(true);
                sumTien -= int.Parse(ds[i].soTien);
                loai.transform.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = ds[i].tenPhanLoai;
            }

        }
        // hiển thị số tiền tự do
        loaiPrefab.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().text = Configs.formatMoney(sumTien + "");
        loaiPrefab.transform.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = "So tien tu do";
    }
    public List<PhanLoai> getList()
    {
        return ds;
    }
    public void themPhanLoai(Transform pl)
    {

        string tmp = loaiPrefab.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().text.Replace(".", "");
        tmp = tmp.Substring(0, tmp.Length - 2);
        int tienTd = int.Parse(tmp);
        try
        {
            // lỗi chưa nhập tiền
            if (pl.Find("Panel").Find("NhapTien").GetComponent<TMP_InputField>().text == "")
            {
                ThongBaoPanel.instance.showThongBao("Hãy nhập số tiền");
                return;
            }
            // lỗi chưa nhập chú thích
            else if (pl.Find("Panel").Find("NhapChuThich").GetComponent<TMP_InputField>().text == "")
            {
                ThongBaoPanel.instance.showThongBao("Hãy nhập chú thích");
                return;
            }
            // lỗi tiền quá lớn
            else if (int.Parse(pl.Find("Panel").Find("NhapTien").GetComponent<TMP_InputField>().text) > tienTd)
            {
                ThongBaoPanel.instance.showThongBao("Số tiền này lớn hơn số tiền tự do còn lại");
                return;
            }
            // lỗi trùng chú thích
            else
            {
                string chuThichTmp = pl.Find("Panel").Find("NhapChuThich").GetComponent<TMP_InputField>().text;
                foreach (PhanLoai plTmp in ds)
                {
                    if (plTmp.tenPhanLoai == chuThichTmp)
                    {
                        ThongBaoPanel.instance.showThongBao("Đã tồn tại chú thích này");
                        return;
                    }
                }
            }
        }
        catch (OverflowException)
        {
            ThongBaoPanel.instance.showThongBao("Số quá lớn, hãy nhập số nhỏ hơn");
            return;
        }

        PhanLoai p = new PhanLoai(pl.Find("Panel").Find("NhapChuThich").GetComponent<TMP_InputField>().text, pl.Find("Panel").Find("NhapTien").GetComponent<TMP_InputField>().text);
        ds.Add(p);
        SaveAndLoadSystem.SavePhanLoai(this);
        dongPanelThem();
        loadData();
        ThongBaoPanel.instance.showThongBao("Đã thêm phân loại");
    }
    public void xoaPhanLoai(Transform pl)
    {
        deletePanel.SetActive(true);
        deletePanel.GetComponent<PanelXacNhanXoa>().loadData(pl);
    }
    public void xoaPhanLoai2(Transform pl)
    {
        string tien = pl.Find("SoTien").GetComponent<TextMeshProUGUI>().text.Replace(".", "");
        tien = tien.Substring(0, tien.Length - 2);
        string chuThich = pl.Find("ChuThich").GetComponent<TextMeshProUGUI>().text;
        PhanLoai tmp = new PhanLoai(chuThich, tien);
        for (int i = 0; i < ds.Count; i++)
        {
            if (ds[i].tenPhanLoai == chuThich)
            {
                ds.RemoveAt(i);
                SaveAndLoadSystem.SavePhanLoai(this);
                loadData();
                ThongBaoPanel.instance.showThongBao("Đã xóa phân loại");
                break;
            }
        }
    }
    public void OpenAutoAddMoneyPanel(Transform pl)
    {

        if (pl.Find("AutoAddMoney").GetChild(0).GetComponent<Image>().color == new Color(0.5f, 0.5f, 0.5f, 1))
        {
            return;
        }
        string chuThich = pl.Find("ChuThich").GetComponent<TextMeshProUGUI>().text;
        try
        {
            int moneyNeedToAdd = int.Parse(chuThich.Substring(chuThich.LastIndexOf("/") + 1));
            TextMeshProUGUI soTienText = pl.Find("SoTien").GetComponent<TextMeshProUGUI>();
            int soTien = int.Parse(soTienText.text.Replace(".", "").Replace(" đ", "")) + moneyNeedToAdd;
            autoAddMoneyPanel.SetActive(true);
            AutoAddMoneyPanel atmp = autoAddMoneyPanel.GetComponent<AutoAddMoneyPanel>();
            atmp.LoadText(chuThich, moneyNeedToAdd);
            atmp.SetPhanLoaiDangThaoTac(pl);
        }
        catch (Exception)
        {
            ThongBaoPanel.instance.showThongBao("Không tìm thấy số tiền để tự động thêm ở CUỐI chú thích\nVD: /10000");
        }

    }
    public void CloseAutoAddMoneyPanel()
    {
        autoAddMoneyPanel.SetActive(false);

    }

    public void editPhanLoai(Transform pl)
    {
        if (editPanel.activeSelf)
        {
            return;
        }
        ChangeAnim("MoEditPhanLoaiPanel");
        editPanel.SetActive(true);
        editPanel.GetComponent<EditPhanLoaiPanel>().loadData(pl);
    }
    public void moPanelThem()
    {
        if (themPanel.activeSelf)
        {
            return;
        }
        themPanel.SetActive(true);
        ChangeAnim("MoThemPhanLoaiPanel");
    }
    async public void dongPanelThem()
    {
        ChangeAnim("DongThemPhanLoaiPanel");
        await Task.Delay(500);
        themPanel.SetActive(false);
    }
    public void setData(List<PhanLoai> pls)
    {
        ds = pls;
    }
    public void ChangeAnim(string n)
    {
        anim.SetTrigger(n);
    }
}
