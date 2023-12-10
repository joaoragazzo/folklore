
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    
    public SpeedUpgrade()
    {
        
        Name = "Velocidade";
        Description = "Velocidade +15";
        Image = Resources.Load<Sprite>("Images/Upgrades/speedupgradeicon");
        Price = UpgradeController.Stats.speedUpgradePrice;
        UpgradeIncrement = 15;
        Max = int.MaxValue;
    }

    public override bool ApplyUpgrade()
    {
        
        if (PlayerStatsController.Stats.Money >= Price)
        {
            UpgradeController.Stats.speedUpgradePrice *= (int)(UpgradeController.Stats.speedUpgradePrice * 1.10);
            PlayerStatsController.Stats.WalkSpeed *= (float)1.15;
            PlayerStatsController.Stats.Money -= Price;
            PlayerStatsController.Stats.Upgrades.Add(new SpeedUpgrade());
            return true;
        }

        return false;
    }
}
