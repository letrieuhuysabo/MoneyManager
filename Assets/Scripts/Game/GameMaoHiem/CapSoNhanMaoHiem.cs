using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapSoNhanMaoHiem : MonoBehaviour
{
    [SerializeField] List<Image> spriteRenderers;
    [SerializeField] Sprite unchoiceSprite, choiceSprite;
    [SerializeField] List<GameObject> oQuaySos;
    int currentButtonChoice;
    void Awake()
    {
        currentButtonChoice = -1;
        AnCapSoNhan1();
    }
    void OnEnable()
    {
        if (currentButtonChoice != -1)
        {
            DoiCapSoNhan(currentButtonChoice);
        }
    }
    public void DoiCapSoNhan(int n)
    {
        if (currentButtonChoice != -1)
        {
            spriteRenderers[currentButtonChoice].sprite = unchoiceSprite;
        }
        spriteRenderers[n].sprite = choiceSprite;
        currentButtonChoice = n;
    }
    public void AnCapSoNhan1()
    {
        DoiCapSoNhan(0);
        HienOQuaySo(1);
    }
    public void AnCapSoNhan2()
    {
        DoiCapSoNhan(1);
        HienOQuaySo(2);
    }
    public void AnCapSoNhan3()
    {
        DoiCapSoNhan(2);
        HienOQuaySo(3);
    }
    void HienOQuaySo(int soLuong)
    {
        // Debug.Log("hello");
        for (int i = 0; i < oQuaySos.Count; i++)
        {
            if (i < soLuong)
            {
                oQuaySos[i].SetActive(true);
            }
            else
            {
                oQuaySos[i].SetActive(false);
            }
        }
    }
}
