using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    public static BgMusic BgInstance;

    public void Awake()
    {
        if (BgInstance !=null && BgInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
