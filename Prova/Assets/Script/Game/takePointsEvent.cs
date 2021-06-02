using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class takePoinstEvent{
    public static takePoinstEvent instance=new takePoinstEvent();
    public delegate void takePoints();
    public static event takePoints event_point;
    public void OnTakePoint()
    {
        //call the event
        event_point ();
    }
}
