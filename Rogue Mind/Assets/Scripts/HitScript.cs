using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public float knockback = 1f;// the knockback this hit applies to enemies
    public int stun = 1;// the knockback this hit applies to enemies
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 0.15f);//destroy object after 0.15 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnDestroy()
	{
        player.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Moving;
    }
}
