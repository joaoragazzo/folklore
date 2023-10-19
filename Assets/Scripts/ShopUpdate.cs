using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpdate : MonoBehaviour
{
   public GameObject shopIcons;

   public GameObject shopObject;

   private bool showShop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            showShop = !showShop;
        }

        shopObject.SetActive(showShop);

        if (showShop)
        {
            Player.canMove = false;
            DayNightCycle.paused = true;
        }
        else
        {
            Player.canMove = true;
            DayNightCycle.paused = false;
        }

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
