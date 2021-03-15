using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //life
    private int life=3;//10=5 cuori
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    private bool isGrounded;
    public Transform feet;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float hurtForce;
    private bool isJumping;
    public float jumpForce;
    //------------
    private Animator anim;
    private enum State {idle, running, jumping, falling, hurt,die, stop}
    private State state = State.idle;
    private LifeHandler lifeHandler;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if((state!=State.hurt)&&(state!=State.die)){
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }
    private void Update()
    {
        if((state!=State.hurt)&&(state!=State.die)){//sistemare dopo la courines
        
            move();
        }
        AnimationState();
        anim.SetInteger("state", (int)state); //sets animation based on Enumerator state
        
      
    }
    public void move(){
        isGrounded = Physics2D.OverlapCircle(feet.position, checkRadius, whatIsGround);
        //flip
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }else if (moveInput < 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //jump

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            /*state=State.jumping;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;*/
            Jump();
            

        }/*
        if (Input.GetKey(KeyCode.Space) && isJumping==true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;

            }
            else { isJumping = false; }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }*/
    
    }
      private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }
    //enemy collision
     private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            if(state == State.falling)
            {
                Destroy(other.gameObject);
                Jump();
            }
            else
            {
                state = State.hurt;
                //prendo danno
                life--;
                print(life); 
                
                OnButtonClick();            
                if(life<=0){
                    state=State.die;                              
                    StartCoroutine("Die");
                }
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    
                    //Enemy is to my right therefore should be damaged and move left
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    
                    //Enemy is to my left therefore i Should be damaged and move right
                    rb.velocity = new Vector2(+hurtForce, rb.velocity.y);
                }
            }
            
        }
    }
    //die
    //sistemare in una classe apposita
    public delegate void ButtonClick();
    public static event ButtonClick Click;
    public void OnButtonClick()
    {
        //call the event
        Click ();
    }
    IEnumerator Die(){    
        print("inizio a sanguinare");
        yield return new WaitForSeconds(1.5f); 
        print("Alfio non picchiarmi");
        Destroy(this.gameObject);
        yield return new WaitForSeconds(3f); 

    }
    //handle state
    private void AnimationState()
    {
       
        if(state == State.die){
            //call the coroutines
        }
        else if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
       else if (state == State.falling)
        {
            if (Physics2D.OverlapCircle(feet.position, checkRadius, whatIsGround))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            
            if(Mathf.Abs (rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        
        else if(Mathf.Abs (rb.velocity.x) > 2f)
        {
            //Moving
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}
