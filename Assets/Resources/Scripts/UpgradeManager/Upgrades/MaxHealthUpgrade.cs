using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthUpgrade : Upgrade
{
    private PlayerInteraction playerInteraction;
    
    public MaxHealthUpgrade()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();

        Name = "Vida Max.";
        Description = "Vida máxima +5%";
        Image = (Sprite)UnityEngine.Resources.Load("Images/Upgrades/maxhealthupgradeicon");
        Price = 20;
        Max = int.MaxValue;
    }

    public override bool ApplyUpgrade()
    {
        if (playerInteraction.PlayerStats.Money >= Price)
        {
            playerInteraction.PlayerStats.MaxHealth *= (float)1.05;
            playerInteraction.PlayerStats.Money -= Price;
            return true;
        }

        return false;
    }
}
