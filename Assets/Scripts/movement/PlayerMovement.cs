using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //for A&D  /  Right&Left Arrow And Jump Movement
    //for Adding W&S Movement, Remove The Slashes Below And Add Slashes 
    //To Jump Movement Only Also In RigidBody2D Remove Gravity For It

    public float jumpHeight = 1.0f;
    public Rigidbody2D rb;
    public CircleCollider2D circular;
    private bool IsGrounded = true;
    private float MoveX;
    private float jumpForce;
    private bool isJumping;
    private bool jumpKeyHeld;
    public Animator animator;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;


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
                //Debug.Log("test");
                rb.AddForce(new Vector2(0,-500)* rb.mass);
            }

        }

    }
    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal");
        //Remove The Slashes For W & S Movement Only
        //MoveY = Input.GetAxisRaw("Vertical");
        //Slash The Below Line Out For W&S Movement Only

        rb.AddForce(new Vector2(MoveX * 100 * rb.mass, 0));

        //animator
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        //Remove The Slashes For W&S Movement Only
        if (!attacking)
        {

        //rb.velocity = (new Vector2(MoveX * 20, MoveY * 20));
        //Debug.Log(IsGrounded);
        if (Input.GetButtonDown("Attack"))
        {
            attackTimeCounter = attackTime;
                attacking = true;
            animator.SetBool("Attack", true);
            rb.velocity = Vector2.zero;
            
        }
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            jumpKeyHeld = true;
            animator.SetBool("isJumping", true);
            //Remove These 2 Lines Below For W&s Movement Only
            isJumping = true;
            rb.AddForce(new Vector2(0, 10)*jumpForce* rb.mass, ForceMode2D.Impulse);
            IsGrounded = false;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumpKeyHeld = false;
        }
        }
        if (attackTimeCounter >= 0)
        {
            attackTimeCounter -= Time.deltaTime;
            Debug.Log(attackTimeCounter);
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            animator.SetBool("Attack", false);

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
    public void OnTriggerEnter2D()
    {
        //Debug.Log(circular.isTrigger);
        IsGrounded = true;
        animator.SetBool("isJumping", false);
    }
}