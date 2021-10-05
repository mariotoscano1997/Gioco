using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pankar : MonoBehaviour
{
    public int Health=50;
    public GameObject shootPrefab;
    public Transform spawn;
    public GameObject pancaPrefabs;
    private GameObject[] littlePanca;
    public Transform spawnOfPanca;
    private bool lookRight;
    // Start is called before the first frame update
    public int TakeDamage(int damage){
        Health-=damage;
        print("la vita è :"+Health );
        if(Health<=0){
            //call animation

            StartCoroutine("die");
        }else{
            StartCoroutine("hurt");
        }
        
        //call animation damage
        return Health;    
    }
    IEnumerator die(){
        StopCoroutine("shoot");
        gameObject.GetComponent<Animator>().SetInteger("State", 1);
       
        //creo 10 piccoli panka
        littlePanca=new GameObject[10];
        //gameObject.GetComponent<BoxCollider2D>().isTrigger=true;
        for(int i=0; i<10; i++){
            littlePanca[i]=GameObject.Instantiate(pancaPrefabs,spawnOfPanca.position, spawnOfPanca.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        gameObject.GetComponent<Animator>().SetInteger("State", 2);
            
        Destroy(gameObject);
    }
     IEnumerator hurt(){
        gameObject.GetComponent<Animator>().SetInteger("State", 1);
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
    }
    void OnTriggerEnter2D(Collider2D other){

    }
    void Start(){
        StartCoroutine("shoot");
        lookRight=false;
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.getInstance().getPlayer().transform.position.x>gameObject.transform.position.x)
            //è alla mia destra
            transform.eulerAngles = new Vector3(0, -180, 0);
        else
            //è alla mia sinistra
            transform.eulerAngles = new Vector3(0, 0, 0);             
    }
  
    IEnumerator shoot(){
        while(true){
            yield return new WaitForSeconds(2f);
            print("sparo");
            Instantiate(shootPrefab, spawn.position, spawn.rotation);
        }
        
        
    }
}
