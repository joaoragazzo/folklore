using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpeedUpgrade : Upgrade
{
    
    public AxeSpeedUpgrade()
    {

        Name = "Balanço";
        Description = "Balanço +50%";
        Image = Resources.Load<Sprite>("Images/Upgrades/axespeedupgradeicon");
        Price = 20;
        Max = int.MaxValue;
    }

    public override bool ApplyUpgrade()
    {
        if (PlayerStatsController.Stats.Money >= Price)
        {
            PlayerStatsController.Stats.AxeRotateSpeed *= (float)1.5;
            PlayerStatsController.Stats.Money -= Price;
            return true;
        }

        return false;
    }
    
}
