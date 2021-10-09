using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxer : MonoBehaviour
{
    [Header("Speed")]
    public float walkSpeed = 2;
    public float alertSpeed = 5;
    [Header("Triggers")]
    public GameObject triggerRight;
    public GameObject triggerLeft;

    private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isWalking)
        {
            if (triggerRight.GetComponent<OnTriggers>().GetGameObjectsInside().Count == 0 ||
            triggerLeft.GetComponent<OnTriggers>().GetGameObjectsInside().Count == 0)
            {
                walkSpeed *= -1;
                transform.Rotate(0, 180, 0);
            }
            transform.position = new Vector2(transform.position.x + Time.deltaTime * walkSpeed, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isWalking)
        {
            walkSpeed *= -1;
            transform.Rotate(0, 180, 0);
        }
    }

    public void Walk()
    {
        int reverseValue = Random.Range(0, 2);
        if (reverseValue == 0) { 
            walkSpeed *= -1;
        }
        if (walkSpeed > 0)
        { transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z); }
        else
        { transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); }
        isWalking = true;
    }

    public void StopWalking()
    {
        isWalking = false;  
    }

    public void TurnAround()
    {
        //transform.Rotate(0, 180, 0);
        walkSpeed *= -1;
        transform.Rotate(0, 180, 0);
    }

    public void StartAnyCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
