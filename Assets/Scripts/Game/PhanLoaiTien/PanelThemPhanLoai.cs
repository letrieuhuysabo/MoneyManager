using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelThemPhanLoai : MonoBehaviour
{
    [SerializeField] List <TMP_InputField> inputs;
    void OnEnable()
    {
        foreach (TMP_InputField input in inputs){
            input.text = "";
        }
    }
}
