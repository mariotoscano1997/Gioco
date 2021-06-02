using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
   private bool showRank=false;
   private GameObject endUI;
   private GameObject finishUI;
   private int score;
   private bool boost;
   public bool tutorialLoadedFromMenu;
    private GameManager(){
        
        //print("lo sto creando");
        time=0;
        points=0;
        isEndend=false;
        lastCheck=new Vector3(-9.93f,-0.7802977f,-0.023f);
        isCheckpointTrigger=false;
        max_life=PlayerPrefs.GetInt("PlayerMaxLife",4);
        playerCurrentLife=max_life;
        tutorialLoadedFromMenu=false;
    }
   
    public bool checkLifeMax(){
       if(max_life-player.getLife()==0) return true;
       else return false;
    }
    public void setFinishUI(GameObject _finishUI){
        finishUI=_finishUI;
    }
    public void setEndUI(GameObject _endUI){
        endUI=_endUI;
    }
    public GameObject getEndUI(){
        return endUI;
    }
    public static GameManager getInstance() {
        return GameManager._instance;   
    }
    public void SetBoost(){
        boost=true;
    }

    public bool GetBoost(){
        return boost;
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
    public void incPoints(int op){
         points+=op;
    }
    public void decPoints(int op){
        if(points-op<=0)
        {   
            points=0;
            return;
        }
        points-=op;
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
        //GameObject.FindWithTag("endGameUI").Find("UIEndGame").SetActive(true);
        endUI.SetActive(true);
        
        this.player.DestroyPlayer();
        //print("GameOver");
        //if(isCheckpointTrigger==false)
            //nvoke("restart",0);
           // Invoke("reloadFromCheck",2.0f);
        
    }
    public int getScore(){
        return score;
    }
    public int finish(){
        score=scoreCalc();
        int money=PlayerPrefs.GetInt("money",-100);
        if(money==-100)
            money=0;
        money+=score/100;
        PlayerPrefs.SetInt("money",money);
        finishUI.SetActive(true);
        GameObject scoreObject = GameObject.Find("score");
        if(scoreObject==null) return 0;
        else scoreObject.GetComponent<TMPro.TextMeshProUGUI>().text=""+score;
        GameObject moneyObject = GameObject.Find("monete");
        if(moneyObject==null) return 0;
        else moneyObject.GetComponent<TMPro.TextMeshProUGUI>().text=""+score/100;
        //print("il punteggio è: "+score);
        return money;
    }
    private int scoreCalc(){
        float endTime=time;
        int score=(int)(100+points*1000/endTime);
        if(boost){
            score*=2;
            boost=false;
        }

        return score;
    }
    public float getFinalTime(){
        return finalTime;
    }
    public bool getShowRank(){
        return showRank;
    }
    public void setShowRank(bool x){
        showRank=x  ;
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