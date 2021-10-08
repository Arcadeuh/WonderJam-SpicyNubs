using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //for A&D  /  Right&Left Arrow And Jump Movement
    //for Adding W&S Movement, Remove The Slashes Below And Add Slashes 
    //To Jump Movement Only Also In RigidBody2D Remove Gravity For It

    public Rigidbody2D rb;
    public CircleCollider2D circular;
    private bool IsGrounded = true;
    private float MoveX;
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
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        MoveX = Input.GetAxisRaw("Horizontal");
        //Remove The Slashes For W & S Movement Only
        //MoveY = Input.GetAxisRaw("Vertical");
        //Slash The Below Line Out For W&S Movement Only

        rb.AddForce(new Vector2(MoveX * 20, 0));
        //Remove The Slashes For W&S Movement Only

        //rb.velocity = (new Vector2(MoveX * 20, MoveY * 20));


    }
    void Update()
    {
        //Debug.Log(IsGrounded);
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("test");
        }
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            //Remove These 2 Lines Below For W&s Movement Only

            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            IsGrounded = false;
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
        Debug.Log(circular.isTrigger);
        IsGrounded = true;
        
    }
}