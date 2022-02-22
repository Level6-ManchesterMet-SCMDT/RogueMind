using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class WaveData : ScriptableObject
{
    public EnemyData[] enemyData;
    public int[] amount;
}
