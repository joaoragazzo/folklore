using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthUpgrade : Upgrade
{
    public PlayerInteraction playerInteraction;

    public StrengthUpgrade()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();

        Name = "Força";
        Description = "Força +1";
        Image = (Sprite)UnityEngine.Resources.Load("Images/Upgrades/treedamageupgradeicon");
        Price = 35;
        Max = 3;
    }

    public override bool ApplyUpgrade()
    {

        if (playerInteraction.PlayerStats.Money >= Price)
        {
            playerInteraction.PlayerStats.Strength += 1;
            playerInteraction.PlayerStats.Money -= Price;
            return true;
        }
        
        return false;
    }
}
    
