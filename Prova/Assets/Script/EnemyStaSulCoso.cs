using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaSulCoso : MonoBehaviour
{
    public int speed;
    public float distance;
    public Transform groundDetection;
    private bool stop;
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
            if(groundInfo.collider==false)
            {
                GetComponent<Animator>().SetInteger("stop", 1); 
                Invoke("sleep",5);
                stop=true;
             
            
            }

        }
      
    }
    void sleep(){
        
        GetComponent<Animator>().SetInteger("stop", 0);
        if (movingRight==true)
            {
                
                transform.eulerAngles= new Vector3(0, -180, 0);
                movingRight = false;
            }else
            {
            
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        stop=false;
    }
}
