using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public EnemyTypes.EnemyAI aiType;// the Enemies type of AI
    public string name;//name of enemy
    public Sprite sprite;// enemy sprite
    public float hp;// enemy health value
    public float movementSpeed;//enemy movement speed value
    public float damage;//enemy damage value
    public GameObject bulletType;// the type of bullet used by shooters




    


}
