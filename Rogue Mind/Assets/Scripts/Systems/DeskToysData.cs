using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class DeskToysData : ScriptableObject
{
    public Sprite sprite;// the toys sprite
    public string name;// the toys name
    public string description;// the toys descirption
    public DeskToysEnum.DeskToyAI AI;// the toys AI
    public float value1;//a series of value's used by the toy's AI for whatever purpose
    public float value2;
    public float value3;
    public float value4;
    public GameObject gameObject1;//a series of gameobjects used by the toy's AI for whatever purpose
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
}
