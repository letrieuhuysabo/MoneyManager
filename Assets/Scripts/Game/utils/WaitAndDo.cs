using System.Collections;
using UnityEngine;

public class WaitAndDo : MonoBehaviour
{
    public static WaitAndDo instance;
    void Awake()
    {
        instance = this;
    }
    public void WaitAndDoThis(float duration, System.Action action)
    {
        StartCoroutine(WaitAndDoThisCoroutine(duration, action));
    }
    IEnumerator WaitAndDoThisCoroutine(float duration, System.Action action) {
        yield return new WaitForSeconds(duration);
        action?.Invoke();
    }
}
