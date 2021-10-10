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
    public bool enableMovement= true;

    public GameObject interactIcon; //so player can interact and repair antenna
    private Vector2 boxSize = new Vector2(0.1f, 1f);


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

        interactIcon.SetActive(false);  //to interact with antenna
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!IsGrounded)
        {
            if (!jumpKeyHeld || Vector2.Dot(rb.velocity, Vector2.up) < -0.5f)
            {
                //Debug.Log("not held" + jumpKeyHeld);
                rb.AddForce(new Vector2(0, fallingSpeed) * rb.mass);
            }

        }

    }
    void Update()
    {
        if (!enableMovement) { return; }
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
        animator.SetBool("isRunning", MoveX!=0);
        //Remove The Slashes For W&S Movement Only



        //rb.velocity = (new Vector2(MoveX * 20, MoveY * 20));
        //Debug.Log(IsGrounded);
/*
           if (Vector2.Dot(rb.velocity, Vector2.up) < 0.1f)
        {
            
            animator.SetBool("isJumping", true);
        }*/
        if ((Input.GetButtonDown("Jump") && IsGrounded))
        {
            jumpKeyHeld = true;
            animator.SetBool("isJumping", true);
            //Remove These 2 Lines Below For W&s Movement Only
            isJumping = true;
            rb.AddForce(new Vector2(0, 2)*jumpForce* rb.mass, ForceMode2D.Impulse);
            IsGrounded = false;
            //Debug.Log(jumpForce);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumpKeyHeld = false;
        }

        //keypress to interact with antenna
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
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
    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(circular.isTrigger);
        //OnGroundTouched();
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 3 )
        {
            IsGrounded = true;
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }*/
    public void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(circular.isTrigger);
        //OnGroundTouched();
        Debug.Log(collision.gameObject.layer);
        
         if (collision.gameObject.layer == 3)
        {
            IsGrounded = false;
            isJumping = false;
            animator.SetBool("isJumping", true);
        }
    }

    public void SetEnableMovement(bool value)
    {
        this.enableMovement = value;
    }

    public void OnGroundTouched()
    {
        IsGrounded = true;
        isJumping = false;
        Debug.Log(IsGrounded);
        animator.SetBool("isJumping", false);
        }

    public void OnGroundExit()
    {
        IsGrounded = false;
        isJumping = false;
        Debug.Log(IsGrounded);
        animator.SetBool("isJumping", true);
    }

    //script in relevance with Antenna
    public void OpenInteractableIcon()
    {
        interactIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactIcon.SetActive(false);
    }

    public void CheckInteraction()
    {
        RaycastHit2D[] CanInteract = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (CanInteract.Length > 0)
        {
            foreach(RaycastHit2D rc in CanInteract)
            {
                if (rc.transform.GetComponent<AntenneState>())
                {
                    rc.transform.GetComponent<AntenneState>().Interact();
                    return;
                }
            }
        }
    }


}
