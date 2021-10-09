using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MovingPlatform : MonoBehaviour
{

    public Transform pos1, pos2;
    public float speed;
    public Transform[] points;
    public Transform startPos= points[];

    Vector2 nextPos;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startPos].position;
    }

    
    // Update is called once per frame
    private void Update()
    {

        if (Vector2.Distance(transform.position, points[startPos].position < 0.02f))


       /* if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }*/

        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

   

}
