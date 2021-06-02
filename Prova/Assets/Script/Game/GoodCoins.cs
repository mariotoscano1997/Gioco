using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCoins :Coins {
    //public int points;
   public GoodCoins(int gpoints):base(gpoints){
      points=gpoints;
   }
    public override void onTake(){
        GameManager.getInstance().incPoints(10);
        base.onTake();
    }
    
}