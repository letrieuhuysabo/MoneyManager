using UnityEngine;

public class DieuKienGiaoDienMenuTheoTiLeManHinh : MonoBehaviour
{
    [SerializeField] GameObject features1, features2;
    void OnEnable()
    {
        if ((Screen.width * 1f / Screen.height) > 0.5f)
        {
            features2.SetActive(true);
            features1.SetActive(false);
        }
        else
        {
            features1.SetActive(true);
            features2.SetActive(false);
        }
    }
}
