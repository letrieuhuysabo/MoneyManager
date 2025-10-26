using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickFeatures : MonoBehaviour
{
    [SerializeField] RectTransform soDuPanel;
    [SerializeField] List<RectTransform> features;
    GameObject canvasNeedOpen;

    public void openFeature(GameObject canvas)
    {
        // StartCoroutine(hideSoDuPanelAndFeatures());
        canvasNeedOpen = canvas.GetComponent<FeatureLinks>().getCanvasLinked();
        // gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
        canvasNeedOpen.SetActive(true);

    }
    public void openMoreFeatures()
    {
        transform.parent.GetComponent<Animator>().SetTrigger("MoMoreFeatures");
    }
    public void closeMoreFeatures()
    {
        transform.parent.GetComponent<Animator>().SetTrigger("DongMoreFeatures");
    }
}
