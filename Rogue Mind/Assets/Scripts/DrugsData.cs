using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class DrugsData : ScriptableObject
{
    public int healthPercentage;
    public int movementSpeedPercentage;
    public int dashDistancePercentage;
    public int meleeDamagePercentage;
    public int fireRatePercentage;
    public int resistanceToEnemyDamage;
}
