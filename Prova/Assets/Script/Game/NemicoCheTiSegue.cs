using UnityEngine;

public class NemicoCheTiSegue : MonoBehaviour
{
    public int speed;
    private Transform target;
    public float stoppingDistance;
    public Transform GroundDetection;
    public Transform view;  
    public float view_distance;
    private bool movingRight;
    // Start is called before the first frame update
     void OnEnable () {        
        Player.event_health += deleteTarget;
    }
    void Start()
    {
        movingRight = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    public void deleteTarget(){
        if(!GameManager.getInstance().getPlayer()){
            this.target=null;
        }
            
    }
    public void onDestroy(){
        Player.event_health -= deleteTarget;
    }
    void flipL(){
         if (movingRight){
                        transform.eulerAngles = new Vector3(0, 0, 0);
                         movingRight = false;
                    }
    }
    void flipR(){
        if (!movingRight){
                        transform.eulerAngles = new Vector3(0, -180, 0);
                         movingRight = true;
                    }  
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, 0.2f);
        int layer_mask = LayerMask.GetMask("Player");
        RaycastHit2D playerInfor = Physics2D.Raycast(view.position, Vector2.right, view_distance,layer_mask);
        RaycastHit2D playerInfol = Physics2D.Raycast(view.position, Vector2.left, view_distance,layer_mask);
        if (target)
        {
            if (groundInfo.collider == true)
            {
                if(playerInfol.collider==true){
                    flipL();                 
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime*2);
                }
                else if(playerInfor.collider==true) 
                {
                    flipR();                 
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime*2);
                }
                else {
                    transform.Translate(Vector2.left* speed*Time.deltaTime);
                }
                
            }
            else
            {
                if (movingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }


            }
        }
    }
}
