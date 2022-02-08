using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DopamineCounterScript : MonoBehaviour
{
    public Text text;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Dopamine: " + player.GetComponent<PlayerCollisionScript>().Dopamine.ToString();
    }
}
