using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HideTextController : MonoBehaviour
{

    TextMeshProUGUI parentText;
    Image thisImage;
    [SerializeField] HideAll hideAllController;
    // void OnEnable()
    // {
    //     Debug.Log(hideAllController);
    //     if (hideAllController != null){
    //         // Debug.Log("hello");
    //         hideAllController.addHideTextController(this);
    //     }
            
    // }
    void Start()
    {

        parentText = transform.parent.GetComponent<TextMeshProUGUI>();
        thisImage = transform.GetChild(0).GetComponent<Image>();
        if (hideAllController != null)
        {
            hideAllController.addHideTextController(this);
            if (hideAllController.hideAll)
            {
                hide();
            }
            else
            {
                show();
            }
        }
        else
        {
            hide();
        }



    }
    public void hideAndShow()
    {
        Color tmp1 = parentText.color;
        Color tmp2 = thisImage.color;
        // Debug.Log(tmp1.a);
        if (parentText.color.a > 0)
        {
            hide(tmp1, tmp2);
        }
        else
        {
            show(tmp1, tmp2);
        }
    }
    void hide()
    {
        Color tmp1 = parentText.color;
        Color tmp2 = thisImage.color;
        hide(tmp1, tmp2);
    }
    void show()
    {
        Color tmp1 = parentText.color;
        Color tmp2 = thisImage.color;
        show(tmp1, tmp2);
    }
    void hide(Color tmp1, Color tmp2)
    {
        // Debug.Log("hello");


        parentText.color = new Color(tmp1.r, tmp1.g, tmp1.b, 0);
        thisImage.color = new Color(tmp2.r, tmp2.g, tmp2.b, 1);
    }
    void show(Color tmp1, Color tmp2)
    {
        // Debug.Log("pro");
        parentText.color = new Color(tmp1.r, tmp1.g, tmp1.b, 1);
        thisImage.color = new Color(tmp2.r, tmp2.g, tmp2.b, 0);
    }
    void OnDestroy()
    {
        if (hideAllController != null)
            hideAllController.deleteHideTextController(this);
    }

}
