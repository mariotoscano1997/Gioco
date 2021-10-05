using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaSulCoso : MonoBehaviour
{
    public int speed;
    public float distance;
    public Transform groundDetection;
    public Transform view;
    public  bool stop;
    private bool movingRight;
   // Start is called before the first frame update
    void Start()
    {
        movingRight = true;  
        stop=false;     
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop){
             transform.Translate(Vector2.right* speed*Time.deltaTime);
             RaycastHit2D groundInfo=Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
             int layer_mask = LayerMask.GetMask("Ground","Enemy");
             RaycastHit2D wallInfol=Physics2D.Raycast(view.position, Vector2.right, 0.1f,layer_mask);           
            
            bool notGround=groundInfo.collider==false;
            bool panStopped=false;
            bool isWall=false;
            if(wallInfol){
                if(wallInfol.collider.gameObject.tag=="Enemy_pan")
                    panStopped= wallInfol.collider.gameObject.GetComponent<EnemyStaSulCoso>().stop; 
                isWall=wallInfol.collider.gameObject.tag=="Ground";
            }
                       
            if(notGround||panStopped||isWall)
            {
            
                GetComponent<Animator>().SetInteger("stop", 1); 
                Invoke("sleep",5);
                stop=true;

            
            }

        }
      
    }
    void sleep(){
        
        GetComponent<Animator>().SetInteger("stop", 0);
        movingRight = transform.turn(movingRight);
        stop=false;
    }
}
