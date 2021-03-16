using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time_canvas : MonoBehaviour
{
    //private Text timeText;
    public Text timeText;
    void Start()
    {
        //this.timeText = GetComponent<Text>();
    }

    void Update()
    {
        int time = (int) GameManager.getInstance().getTime();
        this.timeText.text = "Time: " + TimeToString(time);
    }
    public string TimeToString(float time)
    {
        string minutes = "" + Mathf.Floor(time / 60);
        string seconds = "" + Mathf.RoundToInt(time % 60);

        if (minutes.Length == 1) {
            minutes = "0" + minutes;
        }
        if (seconds.Length == 1) {
            seconds = "0" + seconds;
        }

        return minutes + ":" + seconds;
    }

}
