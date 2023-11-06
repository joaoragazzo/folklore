using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritChanceUpgrade : Upgrade
{
    
    public CritChanceUpgrade()
    {
        Name = "Chance de Crítico";
        Description = "Chance de Crítico +10";
        Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
        Price = 30;
        Max = 10;
    }

    public override bool ApplyUpgrade()
    {
        if (PlayerStatsController.Stats.Money >= Price)
        {
            PlayerStatsController.Stats.CritChance += 10;
            PlayerStatsController.Stats.Money -= Price;
            return true;
        }

        return false;
    }
}
