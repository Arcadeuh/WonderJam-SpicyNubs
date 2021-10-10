using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaBehaviour : MonoBehaviour
{
    
    public float speed = 10;
    public GameObject triggerRight;
    public GameObject triggerLeft;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(triggerRight.GetComponent<OnTriggers>().GetGameObjectsInside().Count);
        if (triggerRight.GetComponent<OnTriggers>().GetGameObjectsInside().Count == 0 ||
            triggerLeft.GetComponent<OnTriggers>().GetGameObjectsInside().Count == 0)
        {
            ReverseSpeed();
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        transform.position = new Vector2(transform.position.x + Time.deltaTime * speed, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
