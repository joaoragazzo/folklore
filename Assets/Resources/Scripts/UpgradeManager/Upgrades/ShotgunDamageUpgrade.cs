using UnityEngine;
    public class ShotgunDamageUpgrade : Upgrade
    {

        public ShotgunDamageUpgrade()
        {

            Name = "Dano da Shotgun";
            Description = "Dano da Shotgun +10";
            Image = Resources.Load<Sprite>("Images/Upgrades/ESCOPETA");
            Price = UpgradeController.Stats.shotgunDamageUpgradePrice;
            UpgradeIncrement = 10;
            Max = 500;
        }

        public override bool ApplyUpgrade()
        {
            if (PlayerStatsController.Stats.Money >= Price)
            {
                UpgradeController.Stats.shotgunDamageUpgradePrice = (int)(UpgradeController.Stats.shotgunDamageUpgradePrice * 1.05);
                PlayerStatsController.Stats.ShotgunDamage += (float)0.10;
                PlayerStatsController.Stats.Money -= Price;
                PlayerStatsController.Stats.Upgrades.Add(new ShotgunDamageUpgrade());
                return true;
            }

            return false;
        }
    }