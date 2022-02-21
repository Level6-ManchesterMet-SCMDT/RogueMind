using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypes : MonoBehaviour
{
    public EnemyAI aiType;// the type of AI used by this enemy

    public enum EnemyAI// creates the actual Enum
    {
        Follower,// an ai that just follows the player
        Shooter,// an ai that shoots at the player
        Nose,//an ai that runs after the player then does an AOE attack
        Fly,
        
    }
}
