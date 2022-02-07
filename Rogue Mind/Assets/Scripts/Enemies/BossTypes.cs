using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTypes : MonoBehaviour
{
    public BossAI aiType;// the type of AI used by this enemy

    public enum BossAI// creates the actual Enum
    {
        BigSam,// an ai that just follows the player
        

    }// Start is called before the first frame update
}