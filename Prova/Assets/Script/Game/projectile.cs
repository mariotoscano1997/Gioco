using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed=10f;
    public Rigidbody2D rb;
    
   

    // Update is called once per frame
    void Start()
    {
        rb.velocity=transform.right*speed;
        print("rotto");
    }
    void OnTriggerEnter2D(Collider2D other){
        print("mi distruggo");
        Player player= other.GetComponent<Player>();
        if(player!=null){
            player.TakeDamage();
        }
        if(other.gameObject.layer!=9)
            Destroy(gameObject);
    }
}
