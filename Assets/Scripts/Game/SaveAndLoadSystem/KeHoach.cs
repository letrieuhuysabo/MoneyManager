using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeHoach
{
    public string thoiGian;
    public List<string> keHoach;
    public List<string> thucTe;
    public KeHoach()
    {
        thoiGian = "";
        keHoach = new List<string>();
        thucTe = new List<string>();
    }
    public KeHoach(string tG, List<TMP_InputField> keHoach, List<TMP_InputField> thucTe)
    {
        thoiGian = tG;
        this.keHoach = new List<string>();
        this.thucTe = new List<string>();
        
        foreach (TMP_InputField ke in keHoach)
        {
            this.keHoach.Add(ke.text);
        }
        foreach (TMP_InputField ke in thucTe)
        {
            this.thucTe.Add(ke.text);
        }
    }
}
