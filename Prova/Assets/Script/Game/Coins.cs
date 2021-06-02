using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins: MonoBehaviour,ICoins {
    public int points;
    
    public Coins(int points){
        this.points=points;
    }
    
    public virtual void onTake(){
        takePoinstEvent te=new takePoinstEvent();
        takePoinstEvent.instance.OnTakePoint();
        Destroy(gameObject);
    }
}