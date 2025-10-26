using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HideAll : MonoBehaviour
{
    List<HideTextController> dsHideTextController;
    Image thisImage;
    [SerializeField] Sprite hideIcon, showIcon;
    public bool hideAll;
    void Awake()
    {
        dsHideTextController = new List<HideTextController>();
        thisImage = GetComponent<Image>();
        if (hideAll){
            thisImage.sprite = hideIcon;
        }
        else {
            thisImage.sprite = showIcon;
        }
    }
    void OnEnable()
    {
        
    }
    void OnDisable()
    {
        
    }
    public void addHideTextController(HideTextController htc)
    {
        dsHideTextController.Add(htc);
    }
    public void deleteHideTextController(HideTextController htc)
    {
        dsHideTextController.Remove(htc);
    }
    public void hideAndShowAll()
    {

        foreach (HideTextController htc in dsHideTextController)
        {
            
            TextMeshProUGUI tmp1 = htc.transform.parent.GetComponent<TextMeshProUGUI>();
            Image tmp2 = htc.transform.GetChild(0).GetComponent<Image>();
            // Debug.Log(tmp1.a);
            if (!hideAll)
            {
                hide(tmp1, tmp2);
            }
            else
            {
                show(tmp1, tmp2);
            }
        }
        hideAll = !hideAll;
    }
    void hide(TextMeshProUGUI tmp1, Image tmp2)
    {
        tmp1.color = new Color(tmp1.color.r, tmp1.color.g, tmp1.color.b, 0);
        tmp2.color = new Color(tmp2.color.r, tmp2.color.g, tmp2.color.b, 1);
        thisImage.sprite = hideIcon;
    }
    void show(TextMeshProUGUI tmp1, Image tmp2)
    {
        tmp1.color = new Color(tmp1.color.r, tmp1.color.g, tmp1.color.b, 1);
        tmp2.color = new Color(tmp2.color.r, tmp2.color.g, tmp2.color.b, 0);
        thisImage.sprite = showIcon;
    }
}
