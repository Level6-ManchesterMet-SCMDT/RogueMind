using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Click,Dash,DoorClose,DoorOpen,EnemyHit,Footsteps,Gun,Drug,Dopamine,Sword,Hench;
    static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        Click = Resources.Load<AudioClip>("Click");
        Dash = Resources.Load<AudioClip>("Dash");
        DoorClose = Resources.Load<AudioClip>("Door Closing");
        DoorOpen = Resources.Load<AudioClip>("Door Opening");
        EnemyHit = Resources.Load<AudioClip>("Enemy Hit");
        Footsteps = Resources.Load<AudioClip>("Footsteps");
        Gun = Resources.Load<AudioClip>("Gun 1");
        Drug = Resources.Load<AudioClip>("On Drug Clicked");
        Dopamine = Resources.Load<AudioClip>("Pick up dopamine");
        Sword = Resources.Load<AudioClip>("sword");
        Hench = Resources.Load<AudioClip>("Get Hench");
        

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Click":
                audioSrc.PlayOneShot(Click);
                break;
            case "Dash":
                audioSrc.PlayOneShot(Dash);
                break;
            case "DoorClose":
                audioSrc.PlayOneShot(DoorClose);
                break;
            case "DoorOpen":
                audioSrc.PlayOneShot(DoorOpen);
                break;
            case "EnemyHit":
                audioSrc.PlayOneShot(EnemyHit);
                break;
            case "Footsteps":
                audioSrc.PlayOneShot(Footsteps);
                break;
            case "Gun":
                audioSrc.PlayOneShot(Gun);
                break;
            case "Drug":
                audioSrc.PlayOneShot(Drug);
                break;
            case "Dopamine":
                audioSrc.PlayOneShot(Dopamine);
                break;
            case "Sword":
                audioSrc.PlayOneShot(Sword);
                break;
            case "Hench":
                audioSrc.PlayOneShot(Hench);
                break;


        }
    }
}