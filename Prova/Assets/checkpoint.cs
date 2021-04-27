using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Transform checkpointTrasform;
    void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.tag == "Player"){
            GameManager.getInstance().setCheck(checkpointTrasform.position);
            print("checkpoint preso");
        }
    }
}
