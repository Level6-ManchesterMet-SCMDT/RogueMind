using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class SaveManagerScript : MonoBehaviour
{
    public int cash;// the things that can be increased by the gym
    public int gunRate;
    public int swordRate;
    public int swordDamage;
    public int gunDamage;
    public int moveSpeed;
    public int enemyResistance;


    public int gunRatePrice;// the price for each upgrade in the gym
    public int swordRatePrice;
    public int swordDamagePrice;
    public int gunDamagePrice;
    public int moveSpeedPrice;
    public int enemyResistancePrice;

    public string DeskToy1;// the 2 desk toys in use
    public string DeskToy2;

    bool firstChoice = false;// whether the desk toy being chose is the first or second

    string content;// used for writing to the text file
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/Log.txt";// the path to the save file

        if (!File.Exists(path))// if there isn't a save file then make one
        {
            File.AppendAllText(path, WriteToFile(0, 0, 0, 0, 0, 1, 0));

        }
        else
        {
            ReadFromFile();  // read the data from the file found

        }
        if(SceneManager.sceneCount == 1)
		{
            //GameObject test = GameObject.FindGameObjectWithTag("DeskToyManager");// finds the desk toy manager
            //test.GetComponent<DeskToysScript>().RealStart();//runs its real start     
        }
        GameObject test2 = GameObject.FindGameObjectWithTag("DeskToys");// finds the desk toys on the desk
        test2.GetComponent<DeskToysShowScript>().RealStart(GetComponent<SaveManagerScript>());//runs its real start

    }

    void Update()
    {
        

       

    }

    public void NextScene()// used for moving onto the next scene
	{
        Debug.Log("Next Scene");
        string path = Application.dataPath + "/Log.txt";
        File.WriteAllText(path, WriteToFile(cash, gunDamage, swordDamage, gunRate, swordRate, moveSpeed, enemyResistance));// write to the file all current saved data
    }

    string WriteToFile(int cash,int gunDamage, int swordDamage, int gunRate, int swordRate, int moveSpeed, int enemyResistance)// used to write to the save file
	{
        
        content = "cash: " + cash.ToString() + "\n";//adds each piece of data being saved to the file in a new line 
        
        content += "gunRate: " + gunRate.ToString() + "\n";
        
        content += "swordRate: " + swordRate.ToString() + "\n";
       
        content += "swordDamage: " + swordDamage.ToString() + "\n";
        
        content += "gunDamage: " + gunDamage.ToString() + "\n";
        
        content += "moveSpeed: " + moveSpeed.ToString() + "\n";
        
        content += "enemyResistance: " + enemyResistance.ToString() + "\n";

        content += "DeskToy1: " + DeskToy1 + "\n";

        content += "DeskToy2: " + DeskToy2 + "\n";

        Debug.Log(content);
        return content;
        
    }       
    
  
    void ReadFromFile()
	{
        string readFromFilePath = Application.dataPath + "/Log.txt";// read from the file
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        string string1 = fileLines[0].Remove(0, 6);// each line we cut out the text before the actual piece of data 
        string string2 = fileLines[1].Remove(0, 9);
        string string3 = fileLines[2].Remove(0, 11);
        string string4 = fileLines[3].Remove(0, 13);
        string string5 = fileLines[4].Remove(0, 11);
        string string6 = fileLines[5].Remove(0, 11);
        string string7 = fileLines[6].Remove(0, 17);
        string string8 = fileLines[7].Remove(0, 10);
        string string9 = fileLines[8].Remove(0, 10);


        int.TryParse(string1, out cash);// set them to int's and store them
        int.TryParse(string2, out gunRate);
        int.TryParse(string3, out swordRate);
        int.TryParse(string4, out swordDamage);
        int.TryParse(string5, out gunDamage);
        int.TryParse(string6, out moveSpeed);
        int.TryParse(string7, out enemyResistance);
        DeskToy1 = string8;
        DeskToy2 = string9;
    }
    // Update is called once per frame

    public void IncreaseCash(int cashChange)
    {
        cash += cashChange;
    }
    public void DecreaseCash(int cashChange)
    {
        cash -= cashChange;
    }
    public void IncreaseSwordDamage()
    {
        if(cash >= swordDamagePrice)
		{
            swordDamage += 5;
            DecreaseCash(swordDamagePrice);
        }
        
    }
    public void IncreaseGunDamage()
    {
        if (cash >= gunDamagePrice)
        {
            gunDamage += 5;
            DecreaseCash(gunDamagePrice);
        }
    }
    public void IncreaseSwordRate()
    {
        if (cash >= swordRatePrice)
        {
            swordRate += 5;
            DecreaseCash(swordRatePrice);
        }
    }
    public void IncreaseGunRate()
    {
        if (cash >= gunRatePrice)
        {
            gunRate += 5;
            DecreaseCash(gunRatePrice);
        }
    }
    public void IncreasemMoveSpeed()
    {
        if (cash >= moveSpeedPrice)
        {
            moveSpeed *= 2;
            DecreaseCash(moveSpeedPrice);
        }
    }
    public void IncreasemResistance()
    {
        if (cash >= enemyResistancePrice)
        {
            enemyResistance *= 2;
            DecreaseCash(enemyResistancePrice);
        }
        
    }

    public void SelectAtomic()
    {
        if(!firstChoice)
		{
            DeskToy1 = "Atomic";
            firstChoice = true;
		}
        else
		{
            DeskToy2 = "Atomic";
        }
    }
    public void SelectEnergy()
    {
        if (!firstChoice)
        {
            DeskToy1 = "Energy";
            firstChoice = true;
        }
        else
        {
            DeskToy2 = "Energy";
        }
    }
    public void SelectPlumber()
    {
        if (!firstChoice)
        {
            DeskToy1 = "Plumber";
            firstChoice = true;
        }
        else
        {
            DeskToy2 = "Plumber";
        }
    }
    public void SelectDonut()
    {
        if (!firstChoice)
        {
            DeskToy1 = "Donut";
            firstChoice = true;
        }
        else
        {
            DeskToy2 = "Donut";
        }
    }

}
