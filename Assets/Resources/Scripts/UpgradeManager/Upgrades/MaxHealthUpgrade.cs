
using UnityEngine;

public class MaxHealthUpgrade : Upgrade
{
    
    public MaxHealthUpgrade()
    {
        Name = "Vida Max.";
        Description = "Vida máxima +5";
        Image = Resources.Load<Sprite>("Images/Upgrades/maxhealthupgradeicon");
        Price = UpgradeController.Stats.maxHealthUpgradePrice;
        UpgradeIncrement = 5;
        Max = int.MaxValue;
    }

    public override bool ApplyUpgrade()
    {
        if (PlayerStatsController.Stats.Money >= Price)
        {
            UpgradeController.Stats.maxHealthUpgradePrice = (int)(UpgradeController.Stats.maxHealthUpgradePrice* 1.07);
            PlayerStatsController.Stats.MaxHealth *= (float)1.05;
            PlayerStatsController.Stats.Health = PlayerStatsController.Stats.MaxHealth;
            PlayerStatsController.Stats.Money -= Price;
            PlayerStatsController.Stats.Upgrades.Add(new MaxHealthUpgrade());
            return true;
        }

        return false;
    }
}
