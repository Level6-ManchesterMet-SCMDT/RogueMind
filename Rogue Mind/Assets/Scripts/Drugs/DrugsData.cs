using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class DrugsData : ScriptableObject
{
    public Sprite sprite1;
    public Sprite sprite2;
    public float healthPercentage;//the modifier for the players health
    public float movementSpeedPercentage;//the modifier for the players movement speed
    public float dashDistancePercentage;//the modifier for the players dash distance
    public float meleeDamagePercentage;//the modifier for the players melee damage
    public float fireRatePercentage;//the modifier for the players fire rate
    public float resistanceToEnemyDamage;//the modifier for the players resistence to enemy damage
    public string name;//the name of a drug
    public string description;// the description of what the drug does
    public int drugCost;
}
