using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//relevant script to interact with antenna in PlayerCombatScript


[RequireComponent(typeof(BoxCollider2D))]
public abstract class AntenneState : MonoBehaviour
{
    // Start is called before the first frame update

    public abstract void Interact();

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

   

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().OpenInteractableIcon();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().CloseInteractableIcon();
        }
    }*/

}
