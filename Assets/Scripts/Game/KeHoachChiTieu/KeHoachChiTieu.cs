using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeHoachChiTieu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject warningSaveText;
    public static KeHoachChiTieu instance;
    void Awake()
    {
        instance = this;
    }
    public void ExitToMenu()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);

    }
    public void ShowWarningSave(){
        warningSaveText.SetActive(true);
    }
    public void HideWarningSave(){
        warningSaveText.SetActive(false);
    }
}
