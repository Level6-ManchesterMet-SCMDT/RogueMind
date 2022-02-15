using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class BossData : ScriptableObject
{
    public BossTypes.BossAI aiType;// the Boss' type of AI
    public string name;//name of Boss
    public Sprite sprite;// Boss' sprite
    public float hp;// Boss' health value
    public float movementSpeed;//Boss' movement speed value
    public float damage;//Boss' damage value
    public GameObject spawnable;// the type of spawnable the boss can spawn
    public EnemyData spawnableData;// the scriptable that the spawnable might use
    public RuntimeAnimatorController anim;







}
