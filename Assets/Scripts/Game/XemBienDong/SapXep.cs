
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Collections;
using System.Threading.Tasks;
public class SapXep : MonoBehaviour
{
    public class ThoiGianTangDanComparer : IComparer<BienDong>
    {
        public int Compare(BienDong x, BienDong y)
        {
            DateTime bienDongXTime = DateTime.ParseExact(x.getThoiGian(), "dd-MM-yyyy HH:mm:ss", null);
            // Debug.Log(bienDongXTime.Minute);
            DateTime bienDongYTime = DateTime.ParseExact(y.getThoiGian(), "dd-MM-yyyy HH:mm:ss", null);
            return -DateTime.Compare(bienDongXTime, bienDongYTime);
        }
    }
    public class ThoiGianGiamDanComparer : IComparer<BienDong>
    {
        public int Compare(BienDong x, BienDong y)
        {
            DateTime bienDongXTime = DateTime.ParseExact(x.getThoiGian(), "dd-MM-yyyy HH:mm:ss", null);
            DateTime bienDongYTime = DateTime.ParseExact(y.getThoiGian(), "dd-MM-yyyy HH:mm:ss", null);
            return DateTime.Compare(bienDongXTime, bienDongYTime);
        }
    }
    public class DoLonBienDongTangDanComparer : IComparer<BienDong>
    {
        public int Compare(BienDong x, BienDong y)
        {
            int doLonX = int.Parse(x.getSoTien().Substring(1, x.getSoTien().Length - 1));
            int doLonY = int.Parse(y.getSoTien().Substring(1, y.getSoTien().Length - 1));
            return doLonY - doLonX;

        }
    }
    public class DoLonBienDongGiamDanComparer : IComparer<BienDong>
    {
        public int Compare(BienDong x, BienDong y)
        {
            int doLonX = int.Parse(x.getSoTien().Substring(1, x.getSoTien().Length - 1));
            int doLonY = int.Parse(y.getSoTien().Substring(1, y.getSoTien().Length - 1));
            return doLonX - doLonY;
        }
    }
    [SerializeField] TMP_Dropdown cachSapXepDD, tangHayGiamDanDD;
    async void OnEnable()
    {
        await Task.Delay(20);
        sapxep();
    }

    public void sapxep()
    {
        // Debug.Log("hello");
        List<BienDong> danhSach = GetListBienDong();
        if (cachSapXepDD.value == 0)
        { // sap xep theo thoi gian

            if (tangHayGiamDanDD.value == 0)
            { // Từ mới nhất đến cũ nhất
                ThoiGianGiamDanComparer cp = new ThoiGianGiamDanComparer();
                danhSach.Sort(cp);
            }
            else
            { // từ cũ nhất đến mới nhất
                ThoiGianTangDanComparer cp = new ThoiGianTangDanComparer();
                danhSach.Sort(cp);
            }
        }
        else
        { // sap xep theo do lon bien dong
            if (tangHayGiamDanDD.value == 0)
            { // Từ lon den nho
                DoLonBienDongGiamDanComparer cp = new DoLonBienDongGiamDanComparer();
                danhSach.Sort(cp);
            }
            else
            { // từ nho den lon
                DoLonBienDongTangDanComparer cp = new DoLonBienDongTangDanComparer();
                danhSach.Sort(cp);
            }
        }
        // Debug.Log(danhSach[0].getChuThich());
        // Debug.Log(XemBienDong.instance);
        XemBienDong.instance.loadData(danhSach);
    }
    List<BienDong> GetListBienDong()
    {
        List<BienDong> ls = new List<BienDong>();
        foreach (BienDong b in LichSuBienDong.instance.getListBienDong())
        {
            ls.Add((BienDong)b.Clone());
        }
        return ls;

    }
}
