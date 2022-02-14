using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugChoiceScript : MonoBehaviour
{
    GameObject drugSelectionMenu;//the menu used for selecting new drugs
    GameObject roomTemplates;
    GameObject shopRoom;
    public DrugsData[] scriptable;// an array of all the drugs currently in use
    private List<DrugsData> DisplayedDrugs = new List<DrugsData>();// a list of the drugs being displayed on a menu
    public DrugManagerScript drugManager;// the drug manager, which maintains modifiers
    public GameObject shopKeeper;// the games shop keeper

    // Start is called before the first frame update
    void Start()
    {
        drugSelectionMenu = transform.GetChild(0).gameObject;//find the menu
        drugManager = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();//find the drug manager
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms");
    }

    // Update is called once per frame
    void Update()
    {
        if (roomTemplates.gameObject.GetComponent<RoomTemplates>().spawnedShopRoom)
        {
            shopRoom = GameObject.FindGameObjectWithTag("Shop");
            if (shopRoom.GetComponent<SpawnShop>().spawned)
            {
                shopKeeper = GameObject.FindGameObjectWithTag("ShopKeep");//find the shop keeper
                shopKeeper.GetComponent<ShopKeep>().drugsMenu = this.gameObject;// get the shop keepers menu
            }
            else if (shopKeeper == null)
            {
                return;
            }
        }
       
        
        
        if (Input.GetKeyDown(KeyCode.J))// if j is hit
        {
            if(drugSelectionMenu.active == true)// if the menu is on
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
        OnOpen();// sets the drugs displayed in the menu
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
        return scriptable[Random.Range(0, scriptable.Length)];// returns a random drug
	}

    public void AddDrug1()//adds drug 1 to list of effectors
    {
        drugManager.AddEffects(DisplayedDrugs[0]);
        drugSelectionMenu.SetActive(false);//turns off menu
	}
    public void AddDrug2()//adds drug 2 to list of effectors
    {
        drugManager.AddEffects(DisplayedDrugs[1]);
        drugSelectionMenu.SetActive(false);//turns off menu
    }
    public void AddDrug3()//adds drug 3 to list of effectors
    {
        drugManager.AddEffects(DisplayedDrugs[2]);
        drugSelectionMenu.SetActive(false);//turns off menu
    }
}
