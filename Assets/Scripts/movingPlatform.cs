using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float offsetLeft = 0, offsetRight = 0, speed = 1;
    [SerializeField] bool hasReachedRight = false, hasReachedLeft = false;
    LayerMask player;
    Vector3 startPosition = Vector3.zero;

    void Awake()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7);
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7) ;
        {
            collision.collider.transform.SetParent(null);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hasReachedRight)
        {
            if (transform.position.x < startPosition.x + offsetRight)
            {
                Move(offsetRight);
            }
            else if (transform.position.x >= startPosition.x + offsetRight)
            {
                hasReachedRight = true;
                hasReachedLeft = false;
            }
        }
        else if (!hasReachedLeft)
        {
            if (transform.position.x > startPosition.x + offsetLeft)
            {
                Move(offsetLeft);
            }
            else if (transform.position.x <= startPosition.x + offsetLeft)
            {
                hasReachedRight = false;
                hasReachedLeft = true;
            }
        }
    }
    void Move(float offset)
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 new Vector3(startPosition.x + offset,
                                                             transform.position.y,
                                                             transform.position.z),
                                                 speed * Time.deltaTime);
    }
}

