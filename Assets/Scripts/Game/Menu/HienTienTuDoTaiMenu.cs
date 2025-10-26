using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
public class HienTienTuDoTaiMenu : MonoBehaviour
{

    void OnEnable()
    {
        try
        {
            DataPhanLoai dt = SaveAndLoadSystem.LoadPhanLoai();
            List<PhanLoai> ds = dt.ds;
            int tongTien = SaveAndLoadSystem.Load().money;
            foreach (PhanLoai pl in ds)
            {
                tongTien -= int.Parse(pl.soTien);
            }
            GetComponent<TextMeshProUGUI>().text = "(" + formatString(tongTien + "") + " đ)";
        }
        catch (NullReferenceException)
        {
            GetComponent<TextMeshProUGUI>().text = "(0 đ)";
        }

    }
    string formatString(string n)
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
}
