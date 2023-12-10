
using UnityEngine;

public class LuckyUpgrade : Upgrade
{
    public LuckyUpgrade()
    {
        Name = "Sorte";
        Description = "Sorte +10";
        Image = Resources.Load<Sprite>("Images/Upgrades/luckyupgrade");
        Price = UpgradeController.Stats.luckyUpgradePrice;
        UpgradeIncrement = 10;
        Max = 20;
    }

    public override bool ApplyUpgrade()
    {
        if (PlayerStatsController.Stats.CountUpgradeByType<LuckyUpgrade>() == Max)
        {
            return false;
        }
        
        
        if (PlayerStatsController.Stats.Money >= Price)
        {
            UpgradeController.Stats.luckyUpgradePrice = (int)(UpgradeController.Stats.luckyUpgradePrice * 1.10);
            PlayerStatsController.Stats.Lucky += 5;
            PlayerStatsController.Stats.Money -= Price;
            PlayerStatsController.Stats.Upgrades.Add(new LuckyUpgrade());
            return true;
        }

        return false;
    }
}
