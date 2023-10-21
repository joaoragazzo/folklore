using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritChanceUpgrade : Upgrade
{
    private PlayerInteraction playerInteraction;
    
    public CritChanceUpgrade()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();

        Name = "Crit. Chance";
        Description = "Crit. Chance +10%";
        Image = Resources.Load<Sprite>("Images/Upgrades/critchanceupgradeicon");
        Price = 30;
        Max = 10;
    }

    public override bool ApplyUpgrade()
    {
        if (playerInteraction.PlayerStats.Money >= Price)
        {
            playerInteraction.PlayerStats.CritChance += (float)0.10;
            playerInteraction.PlayerStats.Money -= Price;
            return true;
        }

        return false;
    }
}
