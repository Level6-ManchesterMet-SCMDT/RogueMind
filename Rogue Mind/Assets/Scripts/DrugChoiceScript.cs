using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugChoiceScript : MonoBehaviour
{
    GameObject drugSelectionMenu;
    public DrugsData[] scriptable;
    private List<DrugsData> DisplayedDrugs = new List<DrugsData>();
    public DrugManagerScript drugManager;

    // Start is called before the first frame update
    void Start()
    {
        drugSelectionMenu = transform.GetChild(0).gameObject;
        drugManager = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(drugSelectionMenu.active == true)
			{
                drugSelectionMenu.SetActive(false);
            }
            else
			{
                drugSelectionMenu.SetActive(true);
                OnOpen();
            }
            
        }



    }

    public void OnOpen()
	{
        DisplayedDrugs.Clear();
		for (int i = 0; i < 3; i++)
		{
            DrugsData drug1 = RandomDrug();
            DisplayedDrugs.Add(drug1);
            drugSelectionMenu.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = drug1.name;
            drugSelectionMenu.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = drug1.description;
        }
        
	}

    public DrugsData RandomDrug()
	{
        return scriptable[Random.Range(0, scriptable.Length)];
	}

    public void AddDrug1()
	{
        drugManager.AddEffects(DisplayedDrugs[1]);
        drugSelectionMenu.SetActive(false);
	}
    public void AddDrug2()
    {
        drugManager.AddEffects(DisplayedDrugs[2]);
        drugSelectionMenu.SetActive(false);
    }
    public void AddDrug3()
    {
        drugManager.AddEffects(DisplayedDrugs[3]);
        drugSelectionMenu.SetActive(false);
    }
}
