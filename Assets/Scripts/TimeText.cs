using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image backgroundImage;
    public AudioSource notificationAudio;

    public AlarmTime alarmTime;
    public Color alarmColor = Color.green;
    private bool isAlarm = false;
    public GameObject offButton;


    public float updateSeconds = 5;
    private float timeSinceLastUpdate = 999;


    private void Update() {
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= updateSeconds) {
            UpdateClock();
            if (!isAlarm) {
                CheckForAlarm();
            }
            else {
                isAlarm = false;
            }
            timeSinceLastUpdate = 0;
        }

        if (isAlarm) {
            backgroundImage.color = Color.Lerp(Color.black, alarmColor, Mathf.Min(5, timeSinceLastUpdate/5));
        }
    }

    private void UpdateClock() {
        text.text = DateTime.Now.ToString("h:mm");
    }

    private void CheckForAlarm() {
        DateTime now = DateTime.Now;
        if (now.Hour == alarmTime.hour && now.Minute == alarmTime.minute) {
            isAlarm = true;
            offButton.SetActive(true);
            notificationAudio.Play();
        }
    }


    public void SetAlarm(int hour, int minute, bool isPM) {
        alarmTime.hour = isPM ? hour + 12 : hour;
        alarmTime.minute = minute;
        isAlarm = false;
    }

    public void SetAlarm(int hour, int minute) {
        alarmTime.hour = hour;
        alarmTime.minute = minute;
        isAlarm = false;
        backgroundImage.color = Color.black;
    }

    public void StopAlarm() {
        offButton.SetActive(false);
        isAlarm = false;
    }
}


[System.Serializable]
public class AlarmTime {

    public int hour;
    public int minute;

    
}
