using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{
    void Start()
    {
        DataPhanLoai dataPhanLoai = SaveAndLoadSystem.LoadPhanLoai();
        if (dataPhanLoai == null) // chưa có file
        {
            taoPhanLoaiDuTruVaMaoHiem();
        }
        else // có file
        {
            List<PhanLoai> phanLoais = dataPhanLoai.ds;
            if (phanLoais.Count == 0) // chưa có danh sách
            {
                taoPhanLoaiDuTruVaMaoHiem();
            }
        }
    }
    void taoPhanLoaiDuTruVaMaoHiem()
    {
        PhanLoai duTru = new("dự trù", "0", "Chưa có");
        PhanLoai maoHiem = new("mạo hiểm", "0", "Chưa có");
        List<PhanLoai> phanLoais = new();
        phanLoais.Add(duTru);
        phanLoais.Add(maoHiem);
        DataPhanLoai dtPhanLoai = new DataPhanLoai(phanLoais);
        SaveAndLoadSystem.SavePhanLoai(dtPhanLoai);
    }
}
