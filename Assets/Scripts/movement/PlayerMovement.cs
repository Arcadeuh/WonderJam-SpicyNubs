using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //for A&D  /  Right&Left Arrow And Jump Movement
    //for Adding W&S Movement, Remove The Slashes Below And Add Slashes 
    //To Jump Movement Only Also In RigidBody2D Remove Gravity For It

    public float jumpHeight = 1.0f;
    public float speed = 1.0f;
    public float fallingSpeed = -100.0f;
    public Rigidbody2D rb;
    public CircleCollider2D circular;
    private bool IsGrounded = true;
    private float MoveX;
    private float jumpForce;
    private bool isJumping;
    private bool jumpKeyHeld;
    public Animator animator;



    //private float MoveY;
    //private bool DoDeath = true;
    // public GameObject DeathScreen;
    //public GameObject LevelCompleteScreen;
    void Start()
    {
        //DeathScreen.gameObject.SetActive(false);
        //LevelCompleteScreen.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        circular = GetComponent<CircleCollider2D>();
        jumpForce = Mathf.Sqrt(2 * Physics2D.gravity.magnitude * jumpHeight);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        
        if (isJumping)
        {
            if (!jumpKeyHeld && Vector2.Dot(rb.velocity, Vector2.up) > 0)
            {
                //Debug.Log("not held" + jumpKeyHeld);
                rb.AddForce(new Vector2(0, fallingSpeed) * rb.mass);
            }

        }

    }
    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal");
        //Remove The Slashes For W & S Movement Only
        //MoveY = Input.GetAxisRaw("Vertical");
        //Slash The Below Line Out For W&S Movement Only

        rb.AddForce(new Vector2(MoveX * speed * rb.mass, 0));
        if (rb.velocity.x > 0.01f)
            transform.localScale = Vector3.one;
        else if (rb.velocity.x < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        //animator
        //Debug.Log(Mathf.Abs(rb.velocity.x));
        animator.SetBool("isRunning", Mathf.Abs(rb.velocity.x)!=0);
        //Remove The Slashes For W&S Movement Only
        
        

        //rb.velocity = (new Vector2(MoveX * 20, MoveY * 20));
        //Debug.Log(IsGrounded);
       
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            jumpKeyHeld = true;
            animator.SetBool("isJumping", true);
            //Remove These 2 Lines Below For W&s Movement Only
            isJumping = true;
            rb.AddForce(new Vector2(0, 1)*jumpForce* rb.mass, ForceMode2D.Impulse);
            IsGrounded = false;
            //Debug.Log(jumpForce);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumpKeyHeld = false;
        }
        
        
    }

    /*public void OnTriggerEnter2D(Collider2D ob)
    {
        if (DoDeath)
        {
            if (ob.name == "DeathTrigger")
            {
                DeathScreen.gameObject.SetActive(true);
            }
            if (ob.name == "Finish")
            {
                LevelCompleteScreen.gameObject.SetActive(true);
                DoDeath = false;
            }
        }
    }*/

    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(circular.isTrigger);
        //OnGroundTouched();
    }
    

    public void OnGroundTouched()
    {
        IsGrounded = true;
        animator.SetBool("isJumping", false);
    }
}