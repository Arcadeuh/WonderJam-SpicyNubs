using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaBehaviour : MonoBehaviour
{
    
    public float speed = 10;
    public GameObject triggerRight;
    public GameObject triggerLeft;

    private Rigidbody2D rb;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(triggerRight.GetComponent<OnTriggers>().GetGameObjectsInside().Count);
        if (triggerRight.GetComponent<OnTriggers>().GetGameObjectsInside().Count == 0 ||
            triggerLeft.GetComponent<OnTriggers>().GetGameObjectsInside().Count == 0)
        {
            ReverseSpeed();
        }
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        rb.MovePosition(new Vector2(rb.position.x + speed * Time.deltaTime, rb.position.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        ReverseSpeed();
    }

    public void ReverseSpeed()
    {
        speed = -speed;
        if (speed > 0)
        { transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); }
        else
        { transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z); }
    }
}
