using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public DrugsData[] drugsData;
    private List<DrugsData> DisplayedDrugs = new List<DrugsData>();
    public DrugManagerScript drugManager;
    public GameObject menu;
    public GameObject vendingMenu;
    public GameObject[] buttons;
    public SoundManager soundManager;
    GameObject player;
    public Animator transition;
    public GameObject displayDrugs;

    void Start()
    {
        displayDrugs = GameObject.FindGameObjectWithTag("Display");
        drugManager = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();//find the drug manager
        player = GameObject.FindGameObjectWithTag("Player");
        soundManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Moving;
            player.GetComponent<ShootingScript>().currentState = ShootingScript.ShootingState.CanShoot;
            player.GetComponent<MeleeScript>().currentState = MeleeScript.MeleeState.CanHit;
            StartCoroutine(CloseTransition());
        }
    }
    public void CloseMenu()
    {

    }
    public DrugsData RandomDrug()// obtain a random drug from the list of potential ones
    {
        return drugsData[Random.Range(0, drugsData.Length)];// returns a random drug
    }
    public void OpenMenu()
    {
        menu.SetActive(true);
        transition.SetTrigger("Open");
        player.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.menu;
        player.GetComponent<ShootingScript>().currentState = ShootingScript.ShootingState.CantShoot;
        player.GetComponent<MeleeScript>().currentState = MeleeScript.MeleeState.CantHit;
        OnOpen();
    }
    public void OnOpen()// on the opening of the menu
    {
        /*DisplayedDrugs.Clear();//empty list of drugs
        for (int i = 0; i <= buttons.Length; i++)// for 3 drugs
        {
            DrugsData drug1 = RandomDrug();//create a random drug
            DisplayedDrugs.Add(drug1);//add it to list

            buttons[i].GetComponent<ShopButton>().drugName.text = drug1.name;
            buttons[i].GetComponent<ShopButton>().drugDescription.text = drug1.description;
            buttons[i].GetComponent<ShopButton>().drugCost.text = "Cost: " + drug1.drugCost.ToString();
            //drugSelectionMenu.transform.GetChild(i + 2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = drug1.name;//set its name
            //drugSelectionMenu.transform.GetChild(i + 2).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = drug1.description;//set its description
        }*/
        DisplayedDrugs.Clear();//empty list of drugs
        for (int i = 0; i < buttons.Length; i++)// for 3 drugs
        {
            DrugsData adding;
            while (true)
            {
                bool test = true;
                adding = RandomDrug();
                for (int j = 0; j < DisplayedDrugs.Count; j++)
                {
                    if (DisplayedDrugs[j].name == adding.name)
                    {
                        test = false;
                    }
                }
                if (test)
                {
                    break;
                }

            }
            DisplayedDrugs.Add(adding);//add it to list
            Debug.Log(adding.name);

            buttons[i].GetComponent<ShopButton>().drugName.text = adding.name;
            buttons[i].GetComponent<ShopButton>().drugDescription.text = adding.description;
            buttons[i].GetComponent<ShopButton>().drugCost.text = "Cost: " + adding.drugCost.ToString();
            buttons[i].transform.GetChild(3).gameObject.GetComponent<PillBoxMouseOver>().sprite1 = adding.sprite1;
            buttons[i].transform.GetChild(3).gameObject.GetComponent<PillBoxMouseOver>().sprite2 = adding.sprite2;
            buttons[i].transform.GetChild(3).gameObject.GetComponent<PillBoxMouseOver>().setSprite();


        }

    }
    public void AddDrug1()//adds drug 1 to list of effectors
    {
        if (player.GetComponent<PlayerCollisionScript>().Dopamine >= DisplayedDrugs[0].drugCost)
        {
            player.GetComponent<PlayerCollisionScript>().Dopamine -= DisplayedDrugs[0].drugCost;
            drugManager.AddEffects(DisplayedDrugs[0]);
            displayDrugs.GetComponent<DrugDisplaying>().AddDrug(DisplayedDrugs[0]);

        }
        soundManager.PlaySound("ShopPurchase");
        player.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Moving;
        player.GetComponent<ShootingScript>().currentState = ShootingScript.ShootingState.CanShoot;
        player.GetComponent<MeleeScript>().currentState = MeleeScript.MeleeState.CanHit;
        StartCoroutine(CloseTransition());
    }
    public void AddDrug2()//adds drug 2 to list of effectors
    {
        if (player.GetComponent<PlayerCollisionScript>().Dopamine >= DisplayedDrugs[1].drugCost)
        {
            player.GetComponent<PlayerCollisionScript>().Dopamine -= DisplayedDrugs[1].drugCost;
            drugManager.AddEffects(DisplayedDrugs[1]);
            displayDrugs.GetComponent<DrugDisplaying>().AddDrug(DisplayedDrugs[1]);

        }
        soundManager.PlaySound("ShopPurchase");
        player.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Moving;
        player.GetComponent<ShootingScript>().currentState = ShootingScript.ShootingState.CanShoot;
        player.GetComponent<MeleeScript>().currentState = MeleeScript.MeleeState.CanHit;
        StartCoroutine(CloseTransition());

    }
    public void AddDrug3()//adds drug 3 to list of effectors
    {
        if (player.GetComponent<PlayerCollisionScript>().Dopamine >= DisplayedDrugs[2].drugCost)
        {
            player.GetComponent<PlayerCollisionScript>().Dopamine -= DisplayedDrugs[2].drugCost;
            drugManager.AddEffects(DisplayedDrugs[2]);
            displayDrugs.GetComponent<DrugDisplaying>().AddDrug(DisplayedDrugs[2]);

        }
        soundManager.PlaySound("ShopPurchase");
        player.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Moving;
        player.GetComponent<ShootingScript>().currentState = ShootingScript.ShootingState.CanShoot;
        player.GetComponent<MeleeScript>().currentState = MeleeScript.MeleeState.CanHit;
        StartCoroutine(CloseTransition());
    }
    IEnumerator CloseTransition()
    {
        transition.SetTrigger("Close");
        yield return new WaitForSeconds(1.0f);
        menu.SetActive(false);
    }
}
