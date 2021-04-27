using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture sprite;
    public GameObject h;
    public GameObject raw;
    public Texture half_hearth;
    public GameObject[] Options;    
    public int hearth_h;
    public int hearth_w;
     
    void OnEnable () { 
        print("richiamo");       
        //Player.event_health += Change;
        GameManager.event_restart +=onDestroy;
    }
    void Change(){
        //scrivere la gestione dei cuori
        int player_life=GameManager.getInstance().getPlayer().getLife();
        print("vita" +player_life);
        if(player_life%2==0){
                Destroy(Options[player_life/2]);            
        }else{
            Options[(int)Mathf.Floor(((float) player_life)/2)].GetComponent<RawImage>().texture=half_hearth;
        }
    }
    void Start()
    {
        Player.event_health += Change;
        print("Start0");
        //  GameObject h=this.gameObject.GetComponent(typeof(Canvas));
        int max_health=GameManager.getInstance().getPlayer().getLife();
        print("la vita è "+ max_health);
        if(max_health%2==0)
            Options=new GameObject[max_health/2];
        else 
            Options=new GameObject[max_health/2+1];
    //raw=(GameObject)h.GetComponentInChildren(typeof(RawImage));
    int i ;
        for(i=0; i< max_health/2;i++){
            print("Inserisco "+ i);
            //Options[i]=h;
            Options[i]= GameObject.Instantiate(raw);
            Options[i].transform.position=new Vector2(Options[i].transform.position.x-(hearth_w*i),Options[i].transform.position.y );
            
            //Options[i].AddComponent(typeof(RawImage));
            //Options[i].GetComponent<RawImage>().texture=sprite;
            //Options[i].transform.position=raw.transform.position;
            //Options[i].transform.localScale=raw.transform.localScale;
            //Options[i].GetComponent<RawImage>().SetTransform=h.transform;
            //Options[i].texture=sprite;
            //h.AddComponent(typeof(RawImage));
            //  h.GetComponent<RawImage>().texture=sprite;
           Options[i].transform.SetParent(h.transform,false);
        }
        print("questo è l'index " +i);
        if (max_health%2==1){
            print("setto il cuore nero");
            
            Options[(int)Mathf.Floor(((float) max_health)/2)]= GameObject.Instantiate(raw);
            print(new Vector2(Options[i].transform.position.x-(hearth_w*(i)),Options[i].transform.position.y ));
            Options[(int)Mathf.Floor(((float) max_health)/2)].transform.position=new Vector2(Options[i].transform.position.x-(hearth_w*(i)),Options[i].transform.position.y );
            Options[(int)Mathf.Floor(((float) max_health)/2)].GetComponent<RawImage>().texture=half_hearth;
            Options[(int)Mathf.Floor(((float) max_health)/2)].transform.SetParent(h.transform,false);
        }
         
    }
    public void onDestroy(){
        print("sono fen0");
        Player.event_health -= Change;
        //GameManager.event_restart -=Start;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
