using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskToysEnum : MonoBehaviour
{
    public DeskToyAI aiType;// the type of AI used by this enemy

    public enum DeskToyAI// creates the actual Enum
    {
        AtomicFigure,
        EnergyDrink,
        ThePlumber,
        PlasticDonut,

    }
}

