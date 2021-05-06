using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{
    private Transform endTransform;
    void Start(){
        endTransform=gameObject.GetComponent<Transform>();
    }
    void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.tag == "Player"){
            //GameManager.getInstance().setCheck(checkpointTrasform.position);
            print("il Punteggio è "+    GameManager.getInstance().finish());
            print("Fine");
        }
    }
    
}

