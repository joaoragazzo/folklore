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
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.P))
        {
            showShop = !showShop;
        }

        shopObject.SetActive(showShop);

        if (showShop)
        {
            Player.canMove = false;
            Player.canRotate = false;
            Player.canShoot = false;
            DayNightCycle.paused = true;
        }
        else
        {
            Player.canMove = true;
            Player.canShoot = true;
            Player.canRotate = true;
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
