using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCoins : Coins {
    public BadCoins(int bpoints):base(bpoints){
      points=bpoints;
    }

    public override void onTake(){
        GameManager.getInstance().decPoints(15);
        base.onTake();
    }
}