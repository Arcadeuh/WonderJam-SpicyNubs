using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class BrokenAntena : AntenneState
{
    public Sprite damaged;
    public Sprite repaired;

    private SpriteRenderer sr;
    private bool isRepaired;

    public override void Interact()
    {
        if (isRepaired)
            sr.sprite = damaged;
        else
            sr.sprite = repaired;

        isRepaired = !isRepaired;
    }


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = damaged;
    }

    
    public bool GetIsRepaired()
    {
        return isRepaired;  
    }
}
