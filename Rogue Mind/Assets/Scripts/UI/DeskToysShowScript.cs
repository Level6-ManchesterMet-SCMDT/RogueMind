using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskToysShowScript : MonoBehaviour
{
    public List<DeskToysData> toys;// a list of all possible toys
   
   
    public void RealStart(SaveManagerScript saveManager)// the real start to run after the savemanager has read it's file
    {
        

		for (int i = 0; i < toys.Count; i++)// for every toy
		{
            if(saveManager.DeskToy1 == toys[i].name)// if its the same as the active toy
			{
                if(toys[i].sprite != null)
				{
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = toys[i].sprite;// set its sprite on the desk
                }
                
			}
            if (saveManager.DeskToy2 == toys[i].name)
            {
                if (toys[i].sprite != null)
                {
                    transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = toys[i].sprite;
                }
            }
        }

        
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
