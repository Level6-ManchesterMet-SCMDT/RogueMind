using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class DrugsData : ScriptableObject
{
    public float healthPercentage;//the exten
    public float movementSpeedPercentage;
    public float dashDistancePercentage;
    public float meleeDamagePercentage;
    public float fireRatePercentage;
    public float resistanceToEnemyDamage;
    public string name;
    public string description;
}
