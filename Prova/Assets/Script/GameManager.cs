using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager {
   private static GameManager _instance =new GameManager();
   
   private float time;
   private int points;
   private bool isEndend;
   private Vector3 lastCheck;
   private bool isCheckpointTrigger;
   private int max_life;
   private int playerCurrentLife;
   private float finalTime=0;
    private GameManager(){
        
        //print("lo sto creando");
        time=0;
        points=0;
        isEndend=false;
        lastCheck=new Vector3(-0.604f,-0.7802977f,0f);
        isCheckpointTrigger=false;
        max_life=10;
        playerCurrentLife=max_life;
    }
    public static GameManager getInstance() {
        return GameManager._instance;
    }
    public delegate void gameRestart();
    public static event gameRestart event_restart;
    public void OnGameRestart()
    {
        //call the event
        event_restart ();
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
    public void incPoints(int inc){
        points+=inc;
    }
    public void decPoints(int dec){
        points-=dec;
        if(points<0) points=0;
    }
    public int getPoints(){
        return points;
    }
    public int getMaxLife(){
        return max_life;
    }
   
    public bool isAlreadyEndend(){
        return isEndend;
    }
    public void setCheck(Vector3 check){
        lastCheck=check;
        isCheckpointTrigger=true;
    }
    public Vector3 getLastCheck(){
        return lastCheck;
    }
    public bool isCheckPointReached(){
        return isCheckpointTrigger;
    }
    public void GameOver(){
        isEndend=true;
        finalTime=time;
        this.player.DestroyPlayer();
        //print("GameOver");
        //if(isCheckpointTrigger==false)
            //nvoke("restart",0);
           // Invoke("reloadFromCheck",2.0f);
        
    }
    public float getFinalTime(){
        return finalTime;
    }
    public void restart(){
        time=0;
        points=0;
        isEndend=false;
        isCheckpointTrigger=false;
        playerCurrentLife=max_life;
        OnGameRestart();
        lastCheck=new Vector3(-0.604f,-0.7802977f,0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //print("dopo il restart"+player.getLife());
    }
    public void reloadFromCheck(){
        OnGameRestart();
        isEndend=false;
        time=finalTime;
        playerCurrentLife= player.getLife();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public int getPlayerCurrentLife(){
            return playerCurrentLife;
    }



}