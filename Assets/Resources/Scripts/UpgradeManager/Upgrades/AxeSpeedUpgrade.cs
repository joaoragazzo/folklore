using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpeedUpgrade : Upgrade
{
    private PlayerInteraction playerInteraction;
    
    public AxeSpeedUpgrade()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();

        Name = "Balanço";
        Description = "Balanço +50%";
        Image = (Sprite)UnityEngine.Resources.Load("Images/Upgrades/axespeedupgradeicon");
        Price = 20;
        Max = int.MaxValue;
    }

    public override bool ApplyUpgrade()
    {
        if (playerInteraction.PlayerStats.Money >= Price)
        {
            playerInteraction.PlayerStats.AxeRotateSpeed *= (float)1.5;
            playerInteraction.PlayerStats.Money -= Price;
            return true;
        }

        return false;
    }
    
}
