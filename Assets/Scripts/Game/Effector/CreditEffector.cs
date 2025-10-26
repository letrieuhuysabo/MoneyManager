using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditEffector : MonoBehaviour
{
    [SerializeField] Vector2 maxScale, minScale;
    
    Coroutine effectA, effectB;
    [SerializeField] float speedScale;
    string currentEffect;
    void Awake(){
        currentEffect = "A";
    }
    void OnEnable()
    {
        runAnim();
        
    }
    void runAnim(){
        if (currentEffect == "A"){
            effectA = StartCoroutine(EffectA());
        }
        else {
            effectB = StartCoroutine(EffectB());
        }
    }
    void OnDisable()
    {
        if (currentEffect == "A"){
            StopCoroutine(effectA);
        }
        else{
            StopCoroutine(effectB);
        }
    }
    public void changeAnim(){
        if (currentEffect == "A"){
            StopCoroutine(effectA);
            currentEffect = "B";
        }
        else {
            StopCoroutine(effectB);
            currentEffect = "A";
        }
        runAnim();
        // Debug.Log("hello");
    }
    IEnumerator EffectA(){
        float duration = 1/speedScale;
        float tmp = 0;
        while (tmp < duration){
            transform.localScale = new Vector3(Mathf.Lerp(minScale.x,maxScale.x,tmp/duration),Mathf.Lerp(minScale.y,maxScale.y,tmp/duration),0);
            tmp += Time.deltaTime;
            yield return null;
        }
        tmp = duration;
        while (tmp >0){
            transform.localScale = new Vector3(Mathf.Lerp(minScale.x,maxScale.x,tmp/duration),Mathf.Lerp(minScale.y,maxScale.y,tmp/duration),0);
            tmp -= Time.deltaTime;
            yield return null;
        }
        effectA = StartCoroutine(EffectA());
    }
    IEnumerator EffectB(){
        float duration = 1/speedScale;
        float tmp = 0;
        float tmp1 = duration;
        while (tmp < duration){
            transform.localScale = new Vector3(Mathf.Lerp(minScale.x,maxScale.x,tmp/duration),Mathf.Lerp(minScale.y,maxScale.y,tmp1/duration),0);
            tmp += Time.deltaTime;
            tmp1 -= Time.deltaTime;
            yield return null;
        }
        tmp = duration;
        tmp1 = 0;
        while (tmp >0){
            transform.localScale = new Vector3(Mathf.Lerp(minScale.x,maxScale.x,tmp/duration),Mathf.Lerp(minScale.y,maxScale.y,tmp1/duration),0);
            tmp -= Time.deltaTime;
            tmp1 += Time.deltaTime;
            yield return null;
        }
        effectB = StartCoroutine(EffectB());
    }
}
