using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controls : MonoBehaviour
{
    public TextMeshProUGUI menuIcon;
    public GameObject adminMenu;

    public TimeSet hourSetter, minuteSetter;
    public TimeText alarmText;

    private bool adminVisible = false;
    private bool iconVisible = false;



    public void ScreenTapped() {
        if (!adminVisible) {
            iconVisible = !iconVisible;
            menuIcon.gameObject.SetActive(iconVisible);
        }
    }

    public void iconTapped() {
        if (!adminVisible) {
            iconVisible = true;
            adminVisible = true;
            menuIcon.text = "X";
        }
        else {
            adminVisible = false;
            iconVisible = false;
            menuIcon.text = ">";
        }

        adminMenu.SetActive(adminVisible);
        menuIcon.gameObject.SetActive(iconVisible);
    }

    public void SetAlarm() {
        alarmText.SetAlarm(hourSetter.GetTime(), minuteSetter.GetTime());
        adminVisible = false;
        iconVisible = false;
        menuIcon.text = ">";
        adminMenu.SetActive(adminVisible);
        menuIcon.gameObject.SetActive(iconVisible);
    }
}