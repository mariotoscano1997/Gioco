using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension_methods{
    
    public static bool turn(this Transform transform, bool movingRight){
        if(movingRight){
            transform.eulerAngles = new Vector3(0, -180, 0);
            return false;
        }
        else{
            transform.eulerAngles = new Vector3(0, 0, 0);
            return true;
        }
    }
    public static void turnRight(this Transform transform){
            transform.eulerAngles = new Vector3(0, -180, 0);         
        
    }
    public static void turnLeft(this Transform transform){
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

}