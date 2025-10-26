
using UnityEngine;
using TMPro;
using System;
public class DateController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dateText;

    // Update is called once per frame
    void Update()
    {
        DateTime currentDate = DateTime.Now;
        dateText.text = currentDate.ToString("dd-MM-yyyy");
    }
}
