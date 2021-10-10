using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerBehaviour : MonoBehaviour
{
    [Header("Speed")]
    public float walkSpeed = 2;
    public float runSpeed = 5;
    [Header("Triggers")]
    public GameObject triggerBottomRight;
    public GameObject triggerBottomLeft;

    private bool isWalking = false;
    private bool isRunningTowardPlayer = false;
    private bool isFlipped = false;
    private GameObject playerGameobject;

    // Start is called before the first frame update
    void Start()
    {
        playerGameobject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isWalking)
        {
            if (triggerBottomRight.GetComponent<OnTriggers>().GetGameObjectsInside().Count == 0 ||
            triggerBottomLeft.GetComponent<OnTriggers>().GetGameObjectsInside().Count == 0)
            {
                walkSpeed *= -1;
                transform.Find("Body").Rotate(0, 180, 0);
            }
            transform.position = new Vector2(transform.position.x + Time.deltaTime * walkSpeed, transform.position.y);
        }

        else if (isRunningTowardPlayer)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 target = new Vector2(playerGameobject.transform.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, runSpeed * Time.deltaTime);

            List<string> gameObjectsRightTrigger = triggerBottomRight.GetComponent<OnTriggers>().GetGameObjectsInside();
            List<string> gameObjectsLeftTrigger = triggerBottomLeft.GetComponent<OnTriggers>().GetGameObjectsInside();
            if (gameObjectsRightTrigger.Count != 0 &&
                newPos.x - rb.position.x > 0 &&
                !gameObjectsRightTrigger.Contains("Player"))
            {
                transform.position = newPos;
            }
            else if (gameObjectsLeftTrigger.Count != 0 &&
                newPos.x - rb.position.x < 0 &&
                !gameObjectsRightTrigger.Contains("Player"))
            {
                transform.position = newPos;
            }

            Transform bodyTransform = transform.Find("Body");
            if (transform.position.x < playerGameobject.transform.position.x) 
            { bodyTransform.eulerAngles = new Vector3(bodyTransform.position.x, 180, bodyTransform.position.z); }
            else
            { bodyTransform.eulerAngles = new Vector3(bodyTransform.position.x, 0, bodyTransform.position.z); }
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isWalking)
        {
            walkSpeed *= -1;
            transform.Find("Body").Rotate(0, 180, 0);
        }
    }

    public void Walk()
    {
        int reverseValue = Random.Range(0, 2);
        if (reverseValue == 0) { 
            walkSpeed *= -1;
        }
        Transform body = transform.Find("Body");
        if (walkSpeed > 0)
        { body.eulerAngles = new Vector3(body.eulerAngles.x, 180, body.eulerAngles.z); }
        else
        { body.eulerAngles = new Vector3(body.eulerAngles.x, 0, body.eulerAngles.z); }
        isWalking = true;
    }

    public void RunTowardPlayer()
    {
        isRunningTowardPlayer = true;
    }

    public void StopRunTowardPlayer()
    {
        isRunningTowardPlayer = false;
    }

    public void StopWalking()
    {
        isWalking = false;  
    }

    public Coroutine StartAnyCoroutine(IEnumerator coroutine)
    {
        return StartCoroutine(coroutine);
    }

    public void StopAnyCoroutine(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }
}
