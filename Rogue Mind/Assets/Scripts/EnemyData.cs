using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public float hp;
    public float movementSpeed;
    public float damage;
}
