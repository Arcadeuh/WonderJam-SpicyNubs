using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume, pitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
