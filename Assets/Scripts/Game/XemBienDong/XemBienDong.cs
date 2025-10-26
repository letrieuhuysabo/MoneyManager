using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class XemBienDong : MonoBehaviour
{
    [SerializeField] GameObject Menu, prefab, editPanel, confirmEditPanel;
    List<GameObject> l;
    string thoiGian;
    public static XemBienDong instance;
    void Awake()
    {
        instance = this;
        // Debug.Log("hello2");
        l = new List<GameObject>();
    }
    void OnEnable()
    {
        // DateTime dt1 = DateTime.Now;
        // DateTime dt2 = DateTime.Now.AddDays(2);
        // Debug.Log(dt2.CompareTo(dt1));
        try
        {
            loadData(LichSuBienDong.instance.getListBienDong());
        }
        catch (NullReferenceException)
        {
            
        }

    }
    public void loadData(List<BienDong> ds)
    {
        // Debug.Log("hello");
        foreach (var t in l)
        {
            Destroy(t);
        }
        l.Clear();
        List<BienDong> dsBienDong = ds;
        for (int i = dsBienDong.Count - 1; i >= 0; i--)
        {
            if (GreaterAMonth(ConvertToDateTime(dsBienDong[i].getThoiGian()), DateTime.Now))
            {
                dsBienDong.RemoveAt(i);
                i--;
                continue;
            }
            GameObject bienDong = Instantiate(prefab);
            bienDong.transform.SetParent(prefab.transform.parent, false);
            bienDong.SetActive(true);
            bienDong.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().text = (dsBienDong[i].getSoTien() + "")[0] + formatMoney((dsBienDong[i].getSoTien() + "").Substring(1, (dsBienDong[i].getSoTien() + "").Length - 1));
            if (bienDong.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().text[0] == '+')
            {
                bienDong.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().color = Color.green;
            }
            else
            {
                bienDong.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            bienDong.transform.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = dsBienDong[i].getChuThich() + "";
            if (bienDong.transform.Find("ChuThich").GetComponent<TextMeshProUGUI>().text == "")
            {
                bienDong.transform.Find("ChuThich").GetComponent<TextMeshProUGUI>().text = "Khong co chu thich";
            }
            bienDong.transform.Find("ThoiGian").GetComponent<TextMeshProUGUI>().text = dsBienDong[i].getThoiGian() + "";
            l.Add(bienDong);
        }
        // LichSuBienDong.instance.setListBienDong(dsBienDong);
    }
    DateTime ConvertToDateTime(string s)
    {
        string format = "dd-MM-yyyy HH:mm:ss";
        DateTime parsedDate = DateTime.ParseExact(s, format, System.Globalization.CultureInfo.InvariantCulture);
        return parsedDate;
    }
    bool GreaterAMonth(DateTime before, DateTime after)
    {
        return before.AddDays(30).CompareTo(after) == -1;
    }
    public void exit()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void showEditPanel(Transform b)
    {
        thoiGian = b.Find("ThoiGian").GetComponent<TextMeshProUGUI>().text;
        editPanel.SetActive(true);

        Transform oldInfo = editPanel.transform.Find("OldInfo");
        Transform newInfo = editPanel.transform.Find("NewInfo");
        oldInfo.Find("InputField (TMP)").GetComponent<TMP_InputField>().text = b.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().text;
        oldInfo.Find("GiamTien").GetComponent<Toggle>().isOn = (b.transform.Find("SoTien").GetComponent<TextMeshProUGUI>().text[0] == '-');
        oldInfo.Find("ChuThich").GetComponent<TMP_InputField>().text = b.transform.Find("ChuThich").GetComponent<TextMeshProUGUI>().text;
    }
    string formatMoney(string n)
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
    public void hideEditPanel(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void confirmEdit1(TMP_InputField text)
    {
        if (text.text == "")
        {
            ThongBaoPanel.instance.showThongBao("Hãy nhập số tiền");
            return;
        }
        confirmEditPanel.SetActive(true);
    }
    public void cancelConfirm1()
    {
        confirmEditPanel.SetActive(false);
    }
    public void confirmEdit2(Transform b)
    {

        int money = LichSuBienDong.instance.getMoney();
        Transform newInfo = b.Find("NewInfo");

        // check xem tiền tự do có còn đủ để trử hay ko
        string m = b.Find("OldInfo").Find("InputField (TMP)").GetComponent<TMP_InputField>().text;
        m = m.Replace(".", "");
        m = m.Substring(1, m.Length - 1);
        int tienCu = int.Parse(m);
        int tienMoi;
        try
        {
            tienMoi = int.Parse(newInfo.Find("InputField (TMP)").GetComponent<TMP_InputField>().text);
        }
        catch (OverflowException)
        {
            ThongBaoPanel.instance.showThongBao("Số quá lớn, hãy nhập số nhỏ hơn");
            return;
        }
        if (b.Find("OldInfo").Find("GiamTien").GetComponent<Toggle>().isOn)
        {
            tienCu *= -1;
        }
        if (newInfo.Find("GiamTien").GetComponent<Toggle>().isOn)
        {
            tienMoi *= -1;
        }
        if (tienMoi < tienCu && !IsFreeMoneyEnough(money, tienCu - tienMoi))
        {
            ThongBaoPanel.instance.showThongBao("Số tiền tự do không đủ để trừ (" + (tienCu - tienMoi) + "), chỉnh sửa thất bại");
            confirmEditPanel.SetActive(false);
            return;
        }
        tienCu = Mathf.Abs(tienCu);
        
        //

        int tmp = tienCu;
        // return;
        // khoi phuc cai cu
        if (b.Find("OldInfo").Find("GiamTien").GetComponent<Toggle>().isOn)
        {
            money += tmp;

        }
        else
        {
            money -= tmp;
        }
        // cap nhat cai moi

        string soTienMoi = newInfo.Find("InputField (TMP)").GetComponent<TMP_InputField>().text;
        string chuThichMoi = newInfo.Find("ChuThich").GetComponent<TMP_InputField>().text;

        if (newInfo.Find("GiamTien").GetComponent<Toggle>().isOn)
        {
            money -= int.Parse(soTienMoi);
            soTienMoi = "-" + soTienMoi;

        }
        else
        {
            money += int.Parse(soTienMoi);
            soTienMoi = "+" + soTienMoi;
        }
        LichSuBienDong.instance.editBienDong(thoiGian, soTienMoi, chuThichMoi);
        LichSuBienDong.instance.setMoney(money);
        loadData(LichSuBienDong.instance.getListBienDong());
        confirmEditPanel.SetActive(false);
        editPanel.SetActive(false);
    }
    bool IsFreeMoneyEnough(int tongTien, int tienCanTru)
    {
        // return true;
        int tienTuDo = tongTien;
        List<PhanLoai> pls = new List<PhanLoai>();
        pls = SaveAndLoadSystem.LoadPhanLoai().ds;
        foreach (PhanLoai pl in pls)
        {
            tienTuDo -= int.Parse(pl.soTien);
        }
        return tienTuDo >= tienCanTru;

    }
    public void resetData(Transform newInfo)
    {
        newInfo.Find("InputField (TMP)").GetComponent<TMP_InputField>().text = "";
        newInfo.Find("GiamTien").GetComponent<Toggle>().isOn = false;
        newInfo.Find("ChuThich").GetComponent<TMP_InputField>().text = "";
    }
}
