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
        Player.event_health += Change;
    }
    void Change(){
        //scrivere la gestione dei cuori
        int player_life=GameManager.getInstance().getPlayer().getLife();
        if(player_life%2==0){
                Destroy(Options[player_life/2]);            
        }else{
            Options[(int)Mathf.Floor(((float) player_life)/2)].GetComponent<RawImage>().texture=half_hearth;
        }
    }
    void Start()
    {
        //  GameObject h=this.gameObject.GetComponent(typeof(Canvas));
        int max_health=10;
        Options=new GameObject[max_health/2];
    //raw=(GameObject)h.GetComponentInChildren(typeof(RawImage));
        for(int i=0; i< max_health/2;i++){
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
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
