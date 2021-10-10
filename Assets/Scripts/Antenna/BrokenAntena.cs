using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrokenAntena : AntenneState
{
    
    private bool isRepaired = false;
    public Animator animator;
    public override void Interact()
    {
        if (!isRepaired)
        {
            
            animator.SetTrigger("isRepaired");
            Debug.Log(true);
            isRepaired = !isRepaired;

        }       
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public bool GetIsRepaired()
    {
        return isRepaired;  
    }
}
