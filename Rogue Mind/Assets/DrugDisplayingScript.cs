using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugDisplayingScript : MonoBehaviour
{
    public List<Sprite> drugs;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < drugs.Count; i++)
		{
            transform.GetChild(i).gameObject.GetComponent<Image>().sprite = drugs[i];
		}
    }

    public void AddDrug(DrugsData drug)
	{
        drugs.Add(drug.sprite1);
        transform.GetChild(count).gameObject.active = true;
        count++;

	}
}
