using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMaoHiem : MonoBehaviour
{
    [SerializeField] GameObject menu, soTienChanLe, soTienTaiXiu, nutXacNhan, xacNhanPanel, thongBaoThangThua;
    [SerializeField] AdvancedDropdown chanLeDropDown, taiXiuDropDown;
    [SerializeField] TextMeshProUGUI soTienTuDo, soTienMaoHiem;
    [SerializeField] List<GameObject> oQuaySos;
    int tienTuDo, tienMaoHiem;
    public void ExitToMenu()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        // đóng dropdown
        chanLeDropDown.value = 0;
        taiXiuDropDown.value = 0;
        // lấy dữ liệu
        LoadDatas();
    }
    public void LoadDatas()
    {
        tienTuDo = Configs.GetTienTuDo();
        tienMaoHiem = Configs.GetTienMaoHiem();
        soTienTuDo.text = Configs.formatMoney(tienTuDo + "");
        soTienMaoHiem.text = Configs.formatMoney(tienMaoHiem + "");
    }
    public void ThayDoiLuaChonChanLe()
    {
        soTienChanLe.SetActive(chanLeDropDown.value > 0);
        soTienChanLe.GetComponent<TMP_InputField>().text = "";
        nutXacNhan.SetActive(chanLeDropDown.value != 0 || taiXiuDropDown.value != 0);
    }
    public void ThayDoiLuaChonTaiXiu()
    {
        soTienTaiXiu.SetActive(taiXiuDropDown.value > 0);
        soTienTaiXiu.GetComponent<TMP_InputField>().text = "";
        nutXacNhan.SetActive(chanLeDropDown.value != 0 || taiXiuDropDown.value != 0);
    }
    public void AnNutXacNhan()
    {
        int tongCuoc = 0;
        if (soTienChanLe.activeSelf)
        {
            TMP_InputField ipf = soTienChanLe.GetComponent<TMP_InputField>();
            if (ipf.text == "" || int.Parse(ipf.text) % 1000 != 0)
            {
                ThongBaoPanel.instance.showThongBao("Hãy nhập số tiền chia hết cho 1000");
                return;
            }
            tongCuoc += int.Parse(ipf.text);
        }
        if (soTienTaiXiu.activeSelf)
        {
            TMP_InputField ipf = soTienTaiXiu.GetComponent<TMP_InputField>();
            if (ipf.text == "" || int.Parse(ipf.text) % 1000 != 0)
            {
                ThongBaoPanel.instance.showThongBao("Hãy nhập số tiền chia hết cho 1000");
                return;
            }
            tongCuoc += int.Parse(soTienTaiXiu.GetComponent<TMP_InputField>().text);
        }
        int capSoNhan = 0;
        for (int i = 0; i < oQuaySos.Count; i++)
        {
            if (oQuaySos[i].activeInHierarchy)
            {
                capSoNhan++;
            }
        }
        if (tongCuoc * capSoNhan > tienTuDo)
        {
            ThongBaoPanel.instance.showThongBao("Tiền không đủ để cược");
            return;
        }
        if (tongCuoc * capSoNhan > tienMaoHiem)
        {
            ThongBaoPanel.instance.showThongBao("Tiền mạo hiểm không đủ để trả");
            return;
        }
        // đã kiểm soát các ngoại lệ
        xacNhanPanel.SetActive(true);

    }
    public void DongThongBaoThangThua()
    {
        thongBaoThangThua.SetActive(false);
        LoadDatas();
    }
}
