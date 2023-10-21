using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    private PlayerInteraction playerInteraction;
    
    public SpeedUpgrade()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();

        Name = "Velocidade";
        Description = "Velocidade +15%";
        Image = Resources.Load<Sprite>("Images/Upgrades/speedupgradeicon");
        Price = 20;
        Max = int.MaxValue;
    }

    public override bool ApplyUpgrade()
    {
        if (playerInteraction.PlayerStats.Money >= Price)
        {
            playerInteraction.PlayerStats.WalkSpeed *= (float)1.15;
            playerInteraction.PlayerStats.Money -= Price;
            return true;
        }

        return false;
    }
}
