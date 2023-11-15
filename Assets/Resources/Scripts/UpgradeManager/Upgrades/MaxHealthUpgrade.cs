using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthUpgrade : Upgrade
{
    
    public MaxHealthUpgrade()
    {
        Name = "Vida Max.";
        Description = "Vida máxima +5";
        Image = Resources.Load<Sprite>("Images/Upgrades/maxhealthupgradeicon");
        Price = 20;
        UpgradeIncrement = 5;
        Max = int.MaxValue;
    }

    public override bool ApplyUpgrade()
    {
        if (PlayerStatsController.Stats.Money >= Price)
        {
            
            PlayerStatsController.Stats.MaxHealth *= (float)1.05;
            PlayerStatsController.Stats.Health = PlayerStatsController.Stats.MaxHealth;
            PlayerStatsController.Stats.Money -= Price;
            PlayerStatsController.Stats.Upgrades.Add(new MaxHealthUpgrade());
            return true;
        }

        return false;
    }
}
