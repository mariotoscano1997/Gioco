using UnityEngine;
using System.Collections;

public class GCoinsElement : MonoBehaviour 
{    
    public int  points;
    void Start () 
    {
       GoodCoins s= new GoodCoins(points);
    }
}