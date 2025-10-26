using TMPro;
using UnityEngine;

public class GetAndLoadAllDatas : MonoBehaviour
{
    [SerializeField] GameObject menu, panelXacNhanLoad, panelXacNhanXoa, panelYeuCauDong;
    public void ExitToMenu()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void GetAllDatas()
    {
        string datas = SaveAndLoadSystem.CopyAllDatas();
        GUIUtility.systemCopyBuffer = datas;
        ThongBaoPanel.instance.showThongBao("Đã sao chép vào khay nhớ tạm");
    }
    public void LoadAllDatas(TMP_InputField ipf)
    {
        SaveAndLoadSystem.LoadAllDatas(ipf.text);
        ThongBaoPanel.instance.showThongBao("Đã tải toàn bộ dữ liệu");
        panelYeuCauDong.SetActive(true);
        DongPanelXacNhanLoad();
    }
    public void DeleteAllDatas()
    {
        SaveAndLoadSystem.DeleteAllDatas();
        ThongBaoPanel.instance.showThongBao("Đã xóa toàn bộ dữ liệu");
        panelYeuCauDong.SetActive(true);
        DongPanelXacNhanXoa();
    }
    public void MoPanelXacNhanLoad()
    {
        panelXacNhanLoad.SetActive(true);
    }
    public void MoPanelXacNhanXoa()
    {
        panelXacNhanXoa.SetActive(true);
    }
    public void DongPanelXacNhanLoad()
    {
        panelXacNhanLoad.SetActive(false);
    }
    public void DongPanelXacNhanXoa()
    {
        panelXacNhanXoa.SetActive(false);
    }
    public void DongUngDung()
    {
        Application.Quit();
    }
}
