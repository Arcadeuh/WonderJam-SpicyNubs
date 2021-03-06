using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Click, Attack, GetHit, Jump;

    public static SfxManager SfxInstance;

    static AudioSource AudioSrc;

    public Sound[] sounds;

    public void Awake()
    {
        if (SfxInstance != null && SfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        SfxInstance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
     //   Click = Audio.load<AudioClip> ("click_menu_sound");
       // Attack = Audio.FindObjectofType<AudioSource>("Retro_8-Bit_Game-Hit_Hurt_Fall_Drop_10");
         // GetHit = Audio.GetComponents<AudioSource>("Retro_8-Bit_Game-Hit_Hurt_Fall_Drop_13");
        // Jump = Audio.GetComponents<AudioSource>("click_menu_sound");

        AudioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
       /* switch (clip)
        {
            case "Click":
    //            AudioSrc.PlayOneShot(Click);
                break;

            case "Attack":
      //         AudioSrc.PlayOneShot(Attack);
                break;
            case " GetHit":
       //         AudioSrc.PlayOneShot(GetHit);
                break;
            case "Jump":
                AudioSrc.PlayOneShot(Jump);
                break;
            */

        
    }
}
