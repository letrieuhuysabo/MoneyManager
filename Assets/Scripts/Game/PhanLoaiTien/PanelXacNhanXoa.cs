using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelXacNhanXoa : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soTien, chuThich;
    Transform phanLoai;
    public void loadData(Transform pl){
        phanLoai = pl;
        soTien.text = pl.Find("SoTien").GetComponent<TextMeshProUGUI>().text;
        chuThich.text = pl.Find("ChuThich").GetComponent<TextMeshProUGUI>().text;
    }
    public void close(){
        phanLoai = null;
        gameObject.SetActive(false);
    }
    public void confirm(){
        PhanLoaiTien.instance.xoaPhanLoai2(phanLoai);
        close();
    }
}
