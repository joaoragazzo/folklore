
using UnityEngine;

public class StrengthUpgrade : Upgrade
{

    public StrengthUpgrade()
    {
        Name = "Força";
        Description = "Força +1";
        Image = Resources.Load<Sprite>("Images/Upgrades/treedamageupgradeicon");
        Price = 35;
        UpgradeIncrement = 1;
        Max = 3;
    }

    public override bool ApplyUpgrade()
    {
        if (PlayerStatsController.Stats.CountUpgradeByType<StreamingController>() == 3) return false;
        
        
        if (PlayerStatsController.Stats.Money >= Price)
        {
            PlayerStatsController.Stats.Strength += 1;
            PlayerStatsController.Stats.Money -= Price;
            PlayerStatsController.Stats.Upgrades.Add(new StrengthUpgrade());
            return true;
        }
        
        return false;
    }
}
    
