using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataPhanLoai
{
    public List <PhanLoai> ds;
    public DataPhanLoai(PhanLoaiTien pl){
        
        ds = pl.getList();
    }
    public DataPhanLoai(List <PhanLoai> pls){
        ds = pls;
    }
}
