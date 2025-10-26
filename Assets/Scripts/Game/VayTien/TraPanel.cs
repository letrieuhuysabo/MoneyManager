using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TraPanel : MonoBehaviour
{
    void OnEnable()
    {
        KhoanVay khoanVay = SaveAndLoadSystem.LoadKhoanVay();
        int tienVay = Configs.ConvertTienToInt(khoanVay.tienVay);
        int tienLai = Configs.ConvertTienToInt(khoanVay.tienLai);
        int tongNo = tienVay + tienLai;
        transform.Find("Panel").Find("TongNo").GetComponent<TextMeshProUGUI>().text = Configs.formatMoney(tongNo + "");
    }
    public void Confirm()
    {
        int tienTuDo = Configs.GetTienTuDo();
        KhoanVay khoanVay = SaveAndLoadSystem.LoadKhoanVay();
        int tienVay = Configs.ConvertTienToInt(khoanVay.tienVay);
        int tienLai = Configs.ConvertTienToInt(khoanVay.tienLai);
        int tongNo = tienVay + tienLai;
        // Debug.Log(tienTuDo + "-" + tongNo);
        if (tienTuDo >= tongNo)
        {
            DataPhanLoai dataPhanLoai = SaveAndLoadSystem.LoadPhanLoai();
            List<PhanLoai> pls = dataPhanLoai.ds;
            int tienDuocDuaVaoMaoHiem = tienLai / 2;
            int tienDuocDuaVaoDuTru = tienLai - tienDuocDuaVaoMaoHiem;
            int daSua2PhanLoai = 0;
            for (int i = 0; i < pls.Count; i++)
            {
                if (pls[i].tenPhanLoai == "dự trù")
                {
                    int tmp = Configs.ConvertTienToInt(pls[i].soTien);
                    tmp += (tienVay + tienDuocDuaVaoDuTru);
                    pls[i].soTien = tmp + "";
                    daSua2PhanLoai++;
                }
                else if (pls[i].tenPhanLoai == "mạo hiểm")
                {
                    int tmp = Configs.ConvertTienToInt(pls[i].soTien);
                    tmp += tienDuocDuaVaoMaoHiem;
                    pls[i].soTien = tmp + "";
                    daSua2PhanLoai++;
                }
                if (daSua2PhanLoai == 2)
                {
                    break;
                }
            }
            // lưu khoản vay
            KhoanVay kv = new KhoanVay("0", "0", "");
            SaveAndLoadSystem.SaveKhoanVay(kv);
            // lưu phân loại
            DataPhanLoai dt = new DataPhanLoai(pls);
            SaveAndLoadSystem.SavePhanLoai(dt);
            // thông báo
            ThongBaoPanel.instance.showThongBao("Trả thành công");
            // xóa thông tin khoản vay
            ThongTinKhoanVay thongTinKhoanVay = new();
            SaveAndLoadSystem.SaveThongTinKhoanVay(thongTinKhoanVay);
            Dong();
        }
        else
        {
            ThongBaoPanel.instance.showThongBao("Không đủ tiền trả");
            Dong();
        }
    }
    public void Dong()
    {
        VayTienMenu.instance.ShowInfos();
        gameObject.SetActive(false);
    }
}
