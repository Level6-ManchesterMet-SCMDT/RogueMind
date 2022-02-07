using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class DeskToysData : ScriptableObject
{
    public Sprite sprite;
    public string name;
    public string description;
    public DeskToysEnum.DeskToyAI AI;
    public float value1;
    public float value2;
    public float value3;
    public float value4;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
}
