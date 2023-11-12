using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyUpgrade : Upgrade
{
    public LuckyUpgrade()
    {
        Name = "Sorte";
        Description = "Sorte +10";
        Image = Resources.Load<Sprite>("Images/Upgrades/luckyupgrade");
        Price = 30;
        UpgradeIncrement = 10;
        Max = 10;
    }

    public override bool ApplyUpgrade()
    {
        if (PlayerStatsController.Stats.Money >= Price)
        {
            PlayerStatsController.Stats.CritChance += 10;
            PlayerStatsController.Stats.Money -= Price;
            PlayerStatsController.Stats.Upgrades.Add(new LuckyUpgrade());
            return true;
        }

        return false;
    }
}
