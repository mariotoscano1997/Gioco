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
        this.timeText.text = "Time: " + Utils.TimeToString(time);
    }
    
}
