using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    public Text pointText; 
    void OnEnable () {     
       
        
        GameManager.event_restart +=onDestroy;
    }
    void Start(){
        pointText.text=""+GameManager.getInstance().getPoints(); 
        Player.event_point += Change; 
    }
    // Start is called before the first frame update
    void Change()
    {
      pointText.text=""+GameManager.getInstance().getPoints(); 
    }
    public void onDestroy(){
        Player.event_point -= Change;
    }
    
}
