using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connexion : MonoBehaviour
{
    public int maxConnection= 100;
    public GameObject player;
    int currentConnection;
    public Transform playerPoint;
    public float ConnectionRange = 0.5f;
    public LayerMask antenneLayers;

    public float ConnectionRate =   1f;
    float nextConnectionTime = 0f;
    // Update is called once per frame
    void Update()
    {

        Connection(1);

        
        
    }

    private void OnDrawGizmosSelected()
    {
        if (playerPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(playerPoint.position, ConnectionRange);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentConnection = maxConnection;
    }
    public void Connection(int power)
    {
        Collider2D[] hitantenne = Physics2D.OverlapCircleAll(playerPoint.position, ConnectionRange, antenneLayers);
        int isAntenneHere = hitantenne.Length;
        if(isAntenneHere==1)
        {
            if(currentConnection < 100)
            {

            if (Time.time >= nextConnectionTime)
            {
                currentConnection += power*2;
                nextConnectionTime = Time.time + 1f / ConnectionRate;
            }
            }
            
        }
        else
        {
            if (Time.time >= nextConnectionTime)
            {
                currentConnection -= power ;
                nextConnectionTime = Time.time + 1f / ConnectionRate;
            }

        }
        Debug.Log(currentConnection);
        if (currentConnection <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("You are dead");
        Destroy(player, 2);
    }

    
}
