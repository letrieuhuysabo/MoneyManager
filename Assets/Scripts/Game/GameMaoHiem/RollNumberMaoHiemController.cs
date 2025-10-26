using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RollNumberMaoHiemController : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> oQuaySo;
    [SerializeField] List<float> rollTimes;
    [SerializeField] float rollDelay;
    [SerializeField] TMP_InputField soTienChanLe, soTienTaiXiu;
    [SerializeField] AdvancedDropdown dropdownChanLe, dropdownTaiXiu;
    [SerializeField] GameObject thongBaoThangThuaPanel;
    int daRollXong;
    int soTienGiaoDich;
    void OnEnable()
    {
        daRollXong = 0;
        soTienGiaoDich = 0;
        for (int i = 0; i < oQuaySo.Count; i++)
        {
            if (oQuaySo[i].gameObject.activeInHierarchy)
            {
                StartCoroutine(Roll(i, rollTimes[i]));
            }
            else
            {
                daRollXong++;
            }
        }
        // Debug.Log(daRollXong);
        StartCoroutine(KiemTraKetQua());
    }
    IEnumerator Roll(int index, float rollTime)
    {
        float duration = rollTime;
        while (duration > 0)
        {
            int rand = Random.Range(0, 10);
            oQuaySo[index].text = rand + "";
            duration -= rollDelay;
            yield return new WaitForSeconds(rollDelay);
        }
        daRollXong++;
    }
    IEnumerator KiemTraKetQua()
    {
        yield return new WaitUntil(() => daRollXong >= 3);
        // Debug.Log("hello");
        yield return new WaitForSeconds(2);
        if (soTienChanLe.gameObject.activeSelf)
        {
            for (int i = 0; i < oQuaySo.Count; i++)
            {
                if (oQuaySo[i].gameObject.activeInHierarchy)
                {
                    KiemTraChanLe(oQuaySo[i].text);
                }
            }
        }
        if (soTienTaiXiu.gameObject.activeSelf)
        {
            for (int i = 0; i < oQuaySo.Count; i++)
            {
                if (oQuaySo[i].gameObject.activeInHierarchy)
                {
                    KiemTraTaiXiu(oQuaySo[i].text);
                }
            }
        }
        // Debug.Log(soTienGiaoDich);
        // cập nhật dữ liệu
        DataPhanLoai dataPhanLoai = SaveAndLoadSystem.LoadPhanLoai();
        List<PhanLoai> pls = dataPhanLoai.ds;
        for (int i = 0; i < pls.Count; i++)
        {
            if (pls[i].tenPhanLoai == "mạo hiểm")
            {
                int soTien = Configs.ConvertTienToInt(pls[i].soTien);
                soTien -= soTienGiaoDich;
                pls[i].soTien = soTien + "";
                break;
            }
        }
        dataPhanLoai.ds = pls;
        SaveAndLoadSystem.SavePhanLoai(dataPhanLoai);
        // hiện thông báo
        thongBaoThangThuaPanel.SetActive(true);

        if (soTienGiaoDich >= 0) // thắng hoặc hòa
        {
            thongBaoThangThuaPanel.transform.Find("Panel").Find("Title").GetComponent<TextMeshProUGUI>().text = "Bạn đã thắng !";
        }
        else // thua
        {
            thongBaoThangThuaPanel.transform.Find("Panel").Find("Title").GetComponent<TextMeshProUGUI>().text = "Bạn đã thua !";
        }
        thongBaoThangThuaPanel.transform.Find("Panel").Find("SoTienGiaoDich").GetComponent<TextMeshProUGUI>().text = Configs.formatMoney(Mathf.Abs(soTienGiaoDich) + "");
        gameObject.SetActive(false);
    }
    void KiemTraChanLe(string dapAnCuoiCung)
    {
        int tienCuocChanLe = int.Parse(soTienChanLe.text);
        string dapAnCuaToi = dropdownChanLe.optionsList[dropdownChanLe.value].nameText;
        Debug.Log(dapAnCuaToi + "__" + ChanLe(dapAnCuoiCung));
        if (dapAnCuaToi == ChanLe(dapAnCuoiCung))
        {
            // Debug.Log("win");
            soTienGiaoDich += tienCuocChanLe;
        }
        else
        {
            // Debug.Log("lose");
            soTienGiaoDich -= tienCuocChanLe;
        }
    }
    string ChanLe(string s)
    {
        int n = int.Parse(s);
        if (n % 2 == 0)
        {
            return "Chẵn";
        }
        else
        {
            return "Lẻ";
        }
    }
    void KiemTraTaiXiu(string dapAnCuoiCung)
    {
        int tienCuocTaiXiu = int.Parse(soTienTaiXiu.text);
        string dapAnCuaToi = dropdownTaiXiu.optionsList[dropdownTaiXiu.value].nameText;
        Debug.Log(dapAnCuaToi + "__" + TaiXiu(dapAnCuoiCung));
        if (dapAnCuaToi == TaiXiu(dapAnCuoiCung))
        {
            // Debug.Log("win");
            soTienGiaoDich += tienCuocTaiXiu;
        }
        else
        {
            // Debug.Log("lose");
            soTienGiaoDich -= tienCuocTaiXiu;
        }
    }
    string TaiXiu(string s)
    {
        int n = int.Parse(s);
        if (n > 5)
        {
            return "Tài";
        }
        else
        {
            return "Xỉu";
        }
    }
}
