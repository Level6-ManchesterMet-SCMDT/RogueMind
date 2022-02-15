using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public DrugsData[] drugsData;
    private List<DrugsData> DisplayedDrugs = new List<DrugsData>();
    public DrugManagerScript drugManager;
    public GameObject menu;
    public GameObject[] buttons;

    void Start()
    {
        drugManager = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();//find the drug manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public DrugsData RandomDrug()// obtain a random drug from the list of potential ones
    {
        return drugsData[Random.Range(0, drugsData.Length)];// returns a random drug
    }
    public void OnOpen()// on the opening of the menu
    {
        DisplayedDrugs.Clear();//empty list of drugs
        for (int i = 0; i < buttons.Length; i++)// for 3 drugs
        {
            DrugsData drug1 = RandomDrug();//create a random drug
            DisplayedDrugs.Add(drug1);//add it to list

            buttons[i].GetComponent<ShopButton>().drugName.text = drug1.name;
            buttons[i].GetComponent<ShopButton>().drugDescription.text = drug1.description;
            buttons[i].GetComponent<ShopButton>().drugCost.text = "Cost: " + drug1.drugCost.ToString();
            //drugSelectionMenu.transform.GetChild(i + 2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = drug1.name;//set its name
            //drugSelectionMenu.transform.GetChild(i + 2).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = drug1.description;//set its description
        }

    }
    public void AddDrug1()//adds drug 1 to list of effectors
    {
        drugManager.AddEffects(DisplayedDrugs[0]);
        menu.SetActive(false);//turns off menu
    }
    public void AddDrug2()//adds drug 2 to list of effectors
    {
        drugManager.AddEffects(DisplayedDrugs[1]);
        menu.SetActive(false);//turns off menu
    }
    public void AddDrug3()//adds drug 3 to list of effectors
    {
        drugManager.AddEffects(DisplayedDrugs[2]);
        menu.SetActive(false);//turns off menu
    }
}
