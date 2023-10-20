using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgrade
{
    public PlayerInteraction playerInteraction;
    
    public HealthUpgrade()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();
        
        Name = "Força";
        Description = "Aumenta sua força em +1";
        Image = Resources.Load<Sprite>("Images/Upgrades/");
        Price = 35;
    }

    public override void ApplyUpgrade(Player playerstats)
    {
        playerInteraction.PlayerStats.MaxHealth = (float)(playerInteraction.PlayerStats.MaxHealth * 1.05);
    }
}
