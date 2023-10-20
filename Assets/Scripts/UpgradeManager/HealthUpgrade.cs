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
        Description = "Aumenta sua força em +1";
        Image = Resources.Load<Sprite>("Images/Upgrades/treedamageupgradeicon");
        Price = 35;
    }


    public override bool ApplyUpgrade(PlayerStats playerstats)
    {
        if (playerInteraction.PlayerStats.Money >= 35)
        {
            playerInteraction.PlayerStats.Strength += 1;
            playerInteraction.PlayerStats.Money -= 35;
            return true;
        }

        return false;
    }
}
    
