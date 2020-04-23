using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaSulCoso : MonoBehaviour
{
    public int speed;
    public float distance;
    public Transform groundDetection;

    private bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        movingRight = true;       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right* speed*Time.deltaTime);
        RaycastHit2D groundInfo=Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
       if(groundInfo.collider==false)
        {
            print("trovato collissione");
            if (movingRight==true)
            {
                print("qui entro");
                transform.eulerAngles= new Vector3(0, -180, 0);
                movingRight = false;
            }else
            {
                print("tua mamma");
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
