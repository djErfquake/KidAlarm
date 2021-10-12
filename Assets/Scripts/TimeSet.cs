using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeSet : MonoBehaviour
{
    private int max = 24;

    public TextMeshProUGUI timeText;
    private int currentTime = 0;
    public bool isHour = true;
    private int addAmount = 1;
    

    private void Start() {
        int time = 0;
        if (isHour) {
            time = DateTime.Now.Hour;
            max = 24;
            addAmount = 1;
        }
        else {
            time = 0;
            max = 55;
            addAmount = 5;
        }
        AddToNumber(time);
    }

    private void AddToNumber(int addition) {
        currentTime += addition;
        currentTime = Math.Max(0, currentTime);
        currentTime = Math.Min(max, currentTime);
        timeText.text = isHour ? currentTime.ToString() : currentTime.ToString("00");
    }

    public int GetTime() {
        return currentTime;
    }

    public void Plus() {
        AddToNumber(addAmount);
    }

    public void Minus() {
        AddToNumber(-addAmount);
    }
}
