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
        takePoinstEvent.event_point += Change; 
    }
    // Start is called before the first frame update
    void Change()
    {
        print(""+GameManager.getInstance().getPoints());
      pointText.text=""+GameManager.getInstance().getPoints(); 
    }
    public void onDestroy(){
        takePoinstEvent.event_point -= Change;
    }
    
}
