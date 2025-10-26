using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class PhanLoai
{
    public string tenPhanLoai, soTien, capNhatLanCuoi;
    public PhanLoai(string ten, string tien){
        this.tenPhanLoai = ten;
        this.soTien = tien;
        capNhatLanCuoi = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
    }
    public PhanLoai(string ten, string tien, string capNhat)
    {
        this.tenPhanLoai = ten;
        this.soTien = tien;
        this.capNhatLanCuoi = capNhat;
    }
}
