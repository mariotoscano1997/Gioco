using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    private Canvas gameOver;
    public Button reset, reload, exit;
    public Text points;
    // Start is called before the first frame update
    void Start()
    {
        this.gameOver = GetComponent<Canvas>();
        this.gameOver.enabled = false;
        this.reload.GetComponent<Button>().interactable= false;
        reset.GetComponent<Button>().onClick.AddListener(resetOnClick);     
        reload.GetComponent<Button>().onClick.AddListener(resetCheckOnClick);
        exit.GetComponent<Button>().onClick.AddListener(exitApp);
    

    }
    
    // Update is called once per frame
    void Update()
    {
        //print(" il gioco è "+GameManager.getInstance().isAlreadyEndend());
        this.gameOver.enabled = GameManager.getInstance().isAlreadyEndend();
        this.reload.GetComponent<Button>().interactable= GameManager.getInstance().isCheckPointReached();
        points.text="Punteggio "+GameManager.getInstance().getPoints()+ " in "+ Utils.TimeToString(GameManager.getInstance().getFinalTime());
    }
    private void resetOnClick(){
        print("riparto");
        GameManager.getInstance().restart();
    }
    private void resetCheckOnClick(){
        GameManager.getInstance().reloadFromCheck();
    }
    private void exitApp(){
        Application.Quit();
    }
}

