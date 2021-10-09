using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionBehavior: MonoBehaviour
{
    public int maxConnection = 100;
    public GameObject player;
    int currentConnection;
    public Transform playerPoint;
    public float ConnectionRange = 0.5f;
    public LayerMask antenneLayers;

    public float ConnectionRate = 5f;
    float nextConnectionTime = 0f;
    public ConnectionBar connectionBar;
    // Update is called once per frame
    // Start is called before the first frame update
    void Start()
    {
        currentConnection = maxConnection;
        connectionBar.setMaxConnection(maxConnection);
    }

    void FixedUpdate()
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
    public void Connection(int power)
    {
        Collider2D[] hitantenne = Physics2D.OverlapCircleAll(playerPoint.position, ConnectionRange, antenneLayers);
        int isAntenneHere = hitantenne.Length;
        if (isAntenneHere == 1)
        {
            if (currentConnection < 100)
            {

                if (Time.time >= nextConnectionTime)
                {
                    currentConnection += power * 2;
                    nextConnectionTime = Time.time + 1/ConnectionRate;

                }

            }
        }
        else
        {
            if (Time.time >= nextConnectionTime)
            {
                currentConnection -= power;
                nextConnectionTime = Time.time + 1 / ConnectionRate;

            }

        }
        //Debug.Log(currentConnection);
        //Debug.Log(isAntenneHere);
        connectionBar.SetConnection(currentConnection);
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

