using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpdate : MonoBehaviour
{
    public WorldInteraction worldInteraction;
    
    public GameObject shopIcons;

   public GameObject shopObject;

   private bool showShop = false;
    // Start is called before the first frame update

    void Start()
    {
        worldInteraction = new WorldInteraction();
        worldInteraction.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.P))
        {
            showShop = !showShop;
        }

        if (!worldInteraction.worldStats.IsDay)
        {
            showShop = false;
        }
        
        shopObject.SetActive(showShop);

        if (showShop)
        {
            worldInteraction.worldStats.Pause();
        }
        else
        {
            worldInteraction.worldStats.Unpause();
        }

        if (worldInteraction.worldStats.IsDay)
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
