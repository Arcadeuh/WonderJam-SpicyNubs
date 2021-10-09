using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggers : MonoBehaviour
{

    [Header("General")]
    public UnityEvent onTriggerExit;
    public UnityEvent onTriggerEnter;
    [Header("Specific")]
    public string tagToDetect = "";
    public UnityEvent specificTriggerEnter;

    private List<string> gameObjectsInside = new List<string>();

    //~~~~~~Events~~~~~~
    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit.Invoke();
        gameObjectsInside.Remove(collision.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == tagToDetect)
        {
            specificTriggerEnter.Invoke();
        }
        onTriggerExit.Invoke();
        gameObjectsInside.Add(collision.name);
    }

    //~~~~~~Public methods~~~~~~
    public List<string> GetGameObjectsInside()
    {
        return gameObjectsInside;
    }
}
