using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float yearTimePass;
    public float yearLong;
    public int yearPass;

    public TextMeshProUGUI yearUI;
    public TextMeshProUGUI dayUI;

    // Start is called before the first frame update
    void Start()
    {
        yearTimePass = 0;
        yearUI.text = "Year 0";
        dayUI.text = "Day 0";
    }

    // Update is called once per frame
    void Update()
    {
        if(yearLong <= 0) return;
        yearTimePass += Time.deltaTime;
        int day = (int)(yearTimePass / yearLong * 365);
        dayUI.text = "Day " + day.ToString();
        if (yearTimePass >= yearLong)
        {
           yearPass ++;
           yearTimePass = 0;
           yearUI.text = "Year " + yearPass.ToString();
        }
    }
}
