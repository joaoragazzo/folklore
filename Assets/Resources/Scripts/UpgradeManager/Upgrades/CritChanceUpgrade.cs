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

        Name = "Chance de Crítico";
        Description = "Chance de Crítico +10";
        Image = (Sprite)UnityEngine.Resources.Load("Images/Upgrades/critdamageupgrade");
        Price = 30;
        Max = 10;
    }

    public override bool ApplyUpgrade()
    {
        if (playerInteraction.PlayerStats.Money >= Price)
        {
            playerInteraction.PlayerStats.CritChance += 10;
            playerInteraction.PlayerStats.Money -= Price;
            return true;
        }

        return false;
    }
}
