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
    public GameObject shopKeeper;

    // Start is called before the first frame update
    void Start()
    {
        drugSelectionMenu = transform.GetChild(0).gameObject;//find the menu
        drugManager = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();//find the drug manager
    }

    // Update is called once per frame
    void Update()
    {
        shopKeeper = GameObject.FindGameObjectWithTag("ShopKeep");
        shopKeeper.GetComponent<ShopKeep>().drugsMenu = this.gameObject;
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(drugSelectionMenu.active == true)
			{
                drugSelectionMenu.SetActive(false);//turns off menu
            }
            else
			{
                OpenMenu();
                //runs a new set of drug options
            }
            
        }



    }

    public void OpenMenu()
	{
        drugSelectionMenu.SetActive(true);//turns on menu
        OnOpen();
    }

    public void OnOpen()// on the opening of the menu
	{
        DisplayedDrugs.Clear();//empty list of drugs
		for (int i = 0; i < 3; i++)// for 3 drugs
		{
            DrugsData drug1 = RandomDrug();//create a random drug
            DisplayedDrugs.Add(drug1);//add it to list
            
            drugSelectionMenu.transform.GetChild(i+2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = drug1.name;//set its name
            drugSelectionMenu.transform.GetChild(i+2).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = drug1.description;//set its description
        }
        
	}

    public DrugsData RandomDrug()// obtain a random drug from the list of potential ones
	{
        return scriptable[Random.Range(0, scriptable.Length)];
	}

    public void AddDrug1()//adds drug 1 to list of effectors
    {
        drugManager.AddEffects(DisplayedDrugs[1]);
        drugSelectionMenu.SetActive(false);//turns off menu
	}
    public void AddDrug2()//adds drug 2 to list of effectors
    {
        drugManager.AddEffects(DisplayedDrugs[2]);
        drugSelectionMenu.SetActive(false);//turns off menu
    }
    public void AddDrug3()//adds drug 3 to list of effectors
    {
        drugManager.AddEffects(DisplayedDrugs[3]);
        drugSelectionMenu.SetActive(false);//turns off menu
    }
}
