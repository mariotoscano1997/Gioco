using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.tag == "Player"){
            //StartCoroutine("JumpIncreased"); 
            if(!GameManager.getInstance().checkLifeMax()) healPlayer();
            freeda.disable<SpriteRenderer>(gameObject);
            //gameObject.GetComponent<SpriteRenderer>().enabled=false;
            gameObject.GetComponent<BoxCollider2D>().enabled=false;
                  
        }
    }
    public void healPlayer(){
        //increse player life
        GameManager.getInstance().getPlayer().heal(1);
        //update graphic
        Health ScriptLifeUI= GameObject.FindObjectOfType(typeof(Health)) as Health;
        ScriptLifeUI.addHeart();
        //destroy
        Destroy(gameObject);
    }
}
