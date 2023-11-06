using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthUpgrade : Upgrade
{

    public StrengthUpgrade()
    {
        Name = "Força";
        Description = "Força +1";
        Image = Resources.Load<Sprite>("Images/Upgrades/treedamageupgradeicon");
        Price = 35;
        Max = 3;
    }

    public override bool ApplyUpgrade()
    {

        if (PlayerStatsController.Stats.Money >= Price)
        {
            PlayerStatsController.Stats.Strength += 1;
            PlayerStatsController.Stats.Money -= Price;
            return true;
        }
        
        return false;
    }
}
    
