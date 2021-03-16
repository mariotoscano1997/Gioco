using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour {
    private static GameManager _instance=new GameManager();
   // public static GameManager Instance { get { return _instance; } }
   private float time;
    private GameManager(){
        //print("lo sto creando");
        time=0;
    }
    public static GameManager getInstance() {
        return GameManager._instance;
    }

   /* private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        print("Sono stato chiamato");
    }*/
    private Player player;
    public void setPlayer(Player _p){
        player=_p;
    }
    public Player getPlayer(){
        return player;
    }
    public float getTime(){
        return time;
    }
    public void inc_Time(float inc){
        time+=inc;
    }



}