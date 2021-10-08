using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{

    public float speed = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + Time.deltaTime * speed, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed;
    }

    public void ReverseSpeed()
    {
        speed = -speed;
    }
}
