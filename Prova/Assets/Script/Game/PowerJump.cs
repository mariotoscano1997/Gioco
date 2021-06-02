using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerJump : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpIncrement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.tag == "Player"){
            StartCoroutine("JumpIncreased"); 
            gameObject.GetComponent<SpriteRenderer>().enabled=false;
            gameObject.GetComponent<BoxCollider2D>().enabled=false;
                  
        }
    }
    IEnumerator JumpIncreased(){
        GameManager.getInstance().getPlayer().jumpForce+=jumpIncrement;
        print("Salto di più");
        yield return new WaitForSeconds(10f);
        GameManager.getInstance().getPlayer().jumpForce-=jumpIncrement;
        print("Salto normale");
        Destroy(gameObject);
    }
}
