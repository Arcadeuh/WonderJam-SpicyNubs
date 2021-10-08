using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggers : MonoBehaviour
{

    public UnityEvent onTriggerExit;

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit.Invoke();
    }
}
