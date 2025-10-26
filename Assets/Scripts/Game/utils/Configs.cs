using System;
using System.Collections.Generic;

public class Configs
{
    public static int GetTienDuTru()
    {
        DataPhanLoai dtPhanLoai = SaveAndLoadSystem.LoadPhanLoai();
        List<PhanLoai> phanLoais = dtPhanLoai.ds;
        bool flag = true;
        int tienDuTru = 0;
        foreach (PhanLoai pl in phanLoais)
        {
            if (pl.tenPhanLoai == "dự trù")
            {
                tienDuTru = ConvertTienToInt(pl.soTien);
                flag = false;
                break;
            }
        }
        if (flag)
        {
            ThongBaoPanel.instance.showThongBao("Không tìm thấy tiền dự trù");
        }
        return tienDuTru;
    }
    public static int GetTienMaoHiem()
    {
        DataPhanLoai dtPhanLoai = SaveAndLoadSystem.LoadPhanLoai();
        if (dtPhanLoai != null)
        {
            List<PhanLoai> phanLoais = dtPhanLoai.ds;
            bool flag = true;
            int tienMaoHiem = 0;
            foreach (PhanLoai pl in phanLoais)
            {
                if (pl.tenPhanLoai == "mạo hiểm")
                {
                    tienMaoHiem = ConvertTienToInt(pl.soTien);
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                ThongBaoPanel.instance.showThongBao("Không tìm thấy tiền mạo hiểm");
            }
            return tienMaoHiem;
        }
        else
        {
            return 0;
        }
        
    }
    public static int GetTienTuDo()
    {
        int tienTuDo = 0;
        try
        {
            tienTuDo = SaveAndLoadSystem.Load().money;
        }
        catch (NullReferenceException)
        {}
        DataPhanLoai dtPhanLoai = SaveAndLoadSystem.LoadPhanLoai();
        if (dtPhanLoai != null)
        {
            List<PhanLoai> phanLoais = dtPhanLoai.ds;
            foreach (PhanLoai pl in phanLoais)
            {
                tienTuDo -= ConvertTienToInt(pl.soTien);
            }
        }
        
        return tienTuDo;
    }
    public static string formatMoney(string n)
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
        return s + " đ";
    }
    public static DateTime ConvertToDateTime(string s)
    {
        // string ngay = s.Substring(0, 2);
        // string thang = s.Substring(3, 2);
        // string nam = s.Substring(6, 4);
        int nam = int.Parse(s.Substring(6, 4));
        int thang = int.Parse(s.Substring(3, 2));
        int ngay = int.Parse(s.Substring(0, 2));
        DateTime dateTime = new DateTime(nam,thang,ngay);
        return dateTime;
    }
    public static int ConvertTienToInt(String s)
    {
        return int.Parse(s.Replace(".", "").Replace(" đ", ""));
    }
}
