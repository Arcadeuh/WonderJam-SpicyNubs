using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MovingPlatform : MonoBehaviour
{

    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
   
    Vector2 nextPos;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        
    }

    
    // Update is called once per frame
    private void Update()
    {
        
            if (transform.position.x == pos1.position.x)
            {
                nextPos = pos2.position;
            }
            if (transform.position.x == pos2.position.x)
            {
                nextPos = pos1.position;
            }

            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        
    }

   

}
