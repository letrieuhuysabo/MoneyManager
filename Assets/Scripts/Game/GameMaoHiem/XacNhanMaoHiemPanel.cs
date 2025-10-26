using TMPro;
using UnityEngine;

public class XacNhanMaoHiemPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infos;
    [SerializeField] TMP_InputField soTienChanLe, soTienTaiXiu;
    [SerializeField] AdvancedDropdown dropdownChanLe, dropdownTaiXiu;
    [SerializeField] GameObject rollNumbersController;
    void OnEnable()
    {
        infos.text = "";
        int tongCuoc = 0;
        if (soTienChanLe.gameObject.activeSelf)
        {
            infos.text += dropdownChanLe.optionsList[dropdownChanLe.value].nameText + ":\n" + Configs.formatMoney(soTienChanLe.text) + "\n";
            tongCuoc += int.Parse(soTienChanLe.text);
        }
        if (soTienTaiXiu.gameObject.activeSelf)
        {
            infos.text += dropdownChanLe.optionsList[dropdownChanLe.value].nameText + ":\n" + Configs.formatMoney(soTienTaiXiu.text) + "\n";
            tongCuoc += int.Parse(soTienTaiXiu.text);
        }
        infos.text += "Tổng cược:\n" + Configs.formatMoney(tongCuoc + "");
    }
    public void Confirm()
    {
        rollNumbersController.SetActive(true);
        Exit();
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
