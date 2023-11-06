using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    
    public SpeedUpgrade()
    {
        
        Name = "Velocidade";
        Description = "Velocidade +15%";
        Image = Resources.Load<Sprite>("Images/Upgrades/speedupgradeicon");
        Price = 20;
        Max = int.MaxValue;
    }

    public override bool ApplyUpgrade()
    {
        if (PlayerStatsController.Stats.Money >= Price)
        {
            PlayerStatsController.Stats.WalkSpeed *= (float)1.15;
            PlayerStatsController.Stats.Money -= Price;
            return true;
        }

        return false;
    }
}
