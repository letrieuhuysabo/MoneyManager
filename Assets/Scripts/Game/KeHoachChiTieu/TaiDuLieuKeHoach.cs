using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaiDuLieuKeHoach : MonoBehaviour
{
    [SerializeField] TMP_InputField thoiGianIP;
    [SerializeField] List <TMP_InputField> keHoachIPs;
    [SerializeField] List <TMP_InputField> thucTeIPs;
    void OnEnable()
    {
        Invoke("LoadData", 0.02f);
    }
    void LoadData()
    {
        KeHoach kh = SaveAndLoadSystem.LoadKeHoach();
        if (kh == null){
            kh = new KeHoach();
        }
        thoiGianIP.text = kh.thoiGian;
        for (int i=0;i<kh.keHoach.Count;i++){
            keHoachIPs[i].text = kh.keHoach[i];
        }
        for (int i=0;i<kh.thucTe.Count;i++){
            thucTeIPs[i].text = kh.thucTe[i];
        }
        KeHoachChiTieu.instance.HideWarningSave();
    }
    public void SaveDuLieuKeHoach()
    {
        string tG = thoiGianIP.text;
        KeHoach kh = new KeHoach(tG, keHoachIPs, thucTeIPs);
        SaveAndLoadSystem.SaveKeHoach(kh);
    }
}
