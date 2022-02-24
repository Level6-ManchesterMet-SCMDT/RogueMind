using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public Text drugName;
    public Text drugDescription;
    public Text drugCost;

    public void OnMouseOver2()
    {
        transform.GetChild(3).gameObject.GetComponent<Image>().sprite = transform.GetChild(3).gameObject.GetComponent<PillBoxMouseOver>().sprite2;
        Debug.Log("mouseover");
    }
    public void OnMouseExit2()
    {
        transform.GetChild(3).gameObject.GetComponent<Image>().sprite = transform.GetChild(3).gameObject.GetComponent<PillBoxMouseOver>().sprite1;
        Debug.Log("mousenot");
    }


}
