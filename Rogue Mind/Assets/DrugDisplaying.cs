using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugDisplaying : MonoBehaviour
{
    public List<Sprite> drugs;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < 4; i++)
		{
            transform.GetChild(i).gameObject.active = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < 4; i++)
		{
            transform.GetChild(i).gameObject.GetComponent<Image>().sprite = drugs[i];
        }
        
    }

    public void AddDrug(DrugsData drug)
	{
        transform.GetChild(count).gameObject.active = true;
        drugs.Add(drug.sprite1);
        count++;
	}
}
