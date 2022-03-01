using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Click,Dash,DoorClose,DoorOpen,EnemyHit,Footsteps,Gun,Drug,Dopamine,Sword,Hench;
    public static AudioClip Cymbol, ShopPurchase, OfficeNoise, SamPuke, SamWalk, Samlets, Sword2, Sword3;
    public static AudioClip Crisps, Dave, MenuOpen, EnemyDeath, EnemySpawn, Eyeball, FlyDamage, FlyExplode, FlySound, NoseSound;
    public static AudioClip Pages, Vending, NoseAttack1,NoseAttack2, Reload, Rocks1, Rocks2, SelectNoise, Shoot1, Shoot2,PlayerDamage,SnackBar,Slurp;

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
        Cymbol = Resources.Load<AudioClip>("Cymbol");
        ShopPurchase = Resources.Load<AudioClip>("KA CHING");
        OfficeNoise = Resources.Load<AudioClip>("Office Ambiance");
        SamPuke = Resources.Load<AudioClip>("Sam Puke");
        SamWalk = Resources.Load<AudioClip>("Sam Walk");
        Samlets = Resources.Load<AudioClip>("Samlets Noise");
        Sword2 = Resources.Load<AudioClip>("sword2");
        Sword3 = Resources.Load<AudioClip>("sword3");
        Crisps = Resources.Load<AudioClip>("Crisps");
        Dave = Resources.Load<AudioClip>("Dave");//THIS ONE
        MenuOpen = Resources.Load<AudioClip>("drug menu open noise");
        EnemyDeath = Resources.Load<AudioClip>("enemy die");//THIS ONE
        EnemySpawn = Resources.Load<AudioClip>("enemy spawn cut");//THIS ONE
        Eyeball = Resources.Load<AudioClip>("Eye ball");//THIS ONE
        FlyDamage = Resources.Load<AudioClip>("fly damage");//THIS ONE
        FlyExplode = Resources.Load<AudioClip>("fly explode");//THIS ONE
        FlySound = Resources.Load<AudioClip>("fly sound");//THIS ONE
        NoseSound = Resources.Load<AudioClip>("nose idle");
        Vending = Resources.Load<AudioClip>("Old fridge");
        Pages = Resources.Load<AudioClip>("pages cut");
        NoseAttack1 = Resources.Load<AudioClip>("slap1");
        NoseAttack2 = Resources.Load<AudioClip>("slap2");
        PlayerDamage = Resources.Load<AudioClip>("player damage");
        Rocks1 = Resources.Load<AudioClip>("rocks breaking 1");
        Rocks2 = Resources.Load<AudioClip>("rocks breaking 2");
        Reload = Resources.Load<AudioClip>("reload");///THIS ONE
        SelectNoise = Resources.Load<AudioClip>("select noise");
        SnackBar = Resources.Load<AudioClip>("snack bar");
        Slurp = Resources.Load<AudioClip>("slurp");
        Shoot1 = Resources.Load<AudioClip>("shoot");
        Shoot2 = Resources.Load<AudioClip>("shoot");// NEEDS NEW SOUND






        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopSound()
	{
        audioSrc.Stop();
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
                switch(Random.RandomRange(0,3))
				{
                    case 0:
                        audioSrc.PlayOneShot(Sword);
                        break;
                    case 1:
                        audioSrc.PlayOneShot(Sword2);
                        break;
                    case 2:
                        audioSrc.PlayOneShot(Sword3);
                        break;
                }
                
                break;
            case "Hench":
                audioSrc.PlayOneShot(Hench);
                break;
            case "Cymbol":
                audioSrc.PlayOneShot(Cymbol);
                break;
            case "ShopPurchase":
                audioSrc.PlayOneShot(ShopPurchase);
                break;
            case "OfficeNoise":
                audioSrc.PlayOneShot(OfficeNoise);
                break;
            case "SamPuke":
                audioSrc.PlayOneShot(SamPuke);
                break;
            case "SamWalk":
                audioSrc.PlayOneShot(SamWalk);
                break;
            case "Samlets":
                audioSrc.PlayOneShot(Samlets);
                break;
            case "Crisps":
                audioSrc.PlayOneShot(Crisps);
                break;
            case "Dave":
                audioSrc.PlayOneShot(Dave);
                break;
            case "MenuOpen":
                audioSrc.PlayOneShot(MenuOpen);
                break;
            case "EnemyDeath":
                audioSrc.PlayOneShot(EnemyDeath);
                break;
            case "Eyeball":
                audioSrc.PlayOneShot(Eyeball);
                break;
            case "FlyDamage":
                audioSrc.PlayOneShot(FlyDamage);
                break;
            case "FlyExplode":
                audioSrc.PlayOneShot(FlyExplode);
                break;
            case "FlySound":
                audioSrc.PlayOneShot(FlySound);
                break;
            case "NoseSound":
                audioSrc.PlayOneShot(NoseSound);
                break;
            case "Pages":
                audioSrc.PlayOneShot(Pages);
                break;
            case "Vending":
                audioSrc.PlayOneShot(Vending);
                break;
            case "NoseAttack":
                switch(Random.RandomRange(0,2))
				{
                    case 0:
                        audioSrc.PlayOneShot(NoseAttack1);
                        break;
                    case 1:
                        audioSrc.PlayOneShot(NoseAttack2);
                        break;
				}
                
                break;
            case "Reload":
                audioSrc.PlayOneShot(Reload);
                break;
            case "Rocks":
                switch (Random.RandomRange(0, 2))
                {
                    case 1:
                        audioSrc.PlayOneShot(Rocks1);
                        break;
                    case 2:
                        audioSrc.PlayOneShot(Rocks2);
                        break;
                }
                break;
            case "SelectNoise":
                audioSrc.PlayOneShot(SelectNoise);
                break;
            case "Shoot":
                switch (Random.RandomRange(0, 2))
                {
                    case 0:
                        audioSrc.PlayOneShot(Shoot1);
                        break;
                    case 1:
                        audioSrc.PlayOneShot(Shoot2);
                        break;
                }
                
                break;
            case "PlayerDamage":
                audioSrc.PlayOneShot(PlayerDamage);
                break;
            case "SnackBar":
                audioSrc.PlayOneShot(SnackBar);
                break;
            case "Slurp":
                audioSrc.PlayOneShot(Slurp);
                break;
        }
    }
}