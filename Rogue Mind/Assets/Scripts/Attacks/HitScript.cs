using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public float knockback = 1f;// the knockback this hit applies to enemies
    public int stun = 1;// the knockback this hit applies to enemies
    public float timeTillDestroy = 0.15f;//the time till the hitbox destroys itself
    public GameObject player;
    public int hitNo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//finds the player
        Destroy(gameObject, timeTillDestroy);//destroy object after 0.15 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnDestroy()
	{
        player.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Moving;// sets the players movement state back to moving at the end of an attack
    }

    public void TimeSlowing()
	{
        StartCoroutine(TimeSlow());
	}
    public IEnumerator TimeSlow()
    {
        Time.timeScale = 0.4f;
        yield return new WaitForSeconds(0.2f);//pause inbetween shots
        Time.timeScale = 1f;
    }
}
