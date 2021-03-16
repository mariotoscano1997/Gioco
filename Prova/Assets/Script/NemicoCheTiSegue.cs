using UnityEngine;

public class NemicoCheTiSegue : MonoBehaviour
{
    public int speed;
    private Transform target;
    public float stoppingDistance;
    public Transform GroundDetection;
    private bool movingRight;
    // Start is called before the first frame update
     void OnEnable () {        
        Player.event_health += deleteTarget;
    }
    void Start()
    {
        movingRight = true;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    public void deleteTarget(){
        if(!GameManager.getInstance().getPlayer()){
            this.target=null;
            print("Alfio non mi segue più");
        }
            
    }
    public void onDestroy(){
        Debug.Log("OnDestroy");
        Player.event_health -= deleteTarget;
        print("lo tolgo dalla lista");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, 0.2f);
        if (target&&(Vector2.Distance(transform.position, target.position) > stoppingDistance))
        {
            if (groundInfo.collider == true)
            {
                if (transform.position.x - target.position.x<0)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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
