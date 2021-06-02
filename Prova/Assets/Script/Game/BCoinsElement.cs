using UnityEngine;
using System.Collections;

public class BCoinsElement : MonoBehaviour 
{    
    public int negative_points;
    void Start () 
    {
       BadCoins s= new BadCoins(negative_points);
    }
}