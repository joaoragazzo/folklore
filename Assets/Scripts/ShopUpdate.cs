using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpdate : MonoBehaviour
{
   public GameObject shopIcons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (DayNightCycle.isDay)
        {
            // Se a condição for verdadeira, desative o objeto pai
            shopIcons.SetActive(true);
        }
        else
        { 
            // Se a condição for falsa, ative o objeto pai
            shopIcons.SetActive(false);
        }


    }
}
