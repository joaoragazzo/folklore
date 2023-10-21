using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpdate : MonoBehaviour
{
    public PlayerInteraction playerInteraction = new PlayerInteraction();
    
    public GameObject shopIcons;

   public GameObject shopObject;

   private bool showShop = false;
    // Start is called before the first frame update
    void Start()
    {
        playerInteraction.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.P))
        {
            showShop = !showShop;
        }

        if (!DayNightCycle.isDay)
        {
            showShop = false;
        }
        
        shopObject.SetActive(showShop);

        if (showShop)
        {
            playerInteraction.PlayerStats.Freeze();
            DayNightCycle.paused = true;
        }
        else
        {
            playerInteraction.PlayerStats.Unfreeze();
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
