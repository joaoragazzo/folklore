using UnityEngine;

    public class SniperDamageUpgrade : Upgrade
    {

        public SniperDamageUpgrade()
        {
            Name = "Dano da Sniper";
            Description = "Dano da Sniper +10";
            Image = Resources.Load<Sprite>("Images/Upgrades/AWP");
            Price = UpgradeController.Stats.sniperDamageUpgradePrice;
            UpgradeIncrement = 10;
            Max = 500;
        }

        public override bool ApplyUpgrade()
        {
            if (PlayerStatsController.Stats.Money >= Price)
            {
                UpgradeController.Stats.sniperDamageUpgradePrice = (int)(UpgradeController.Stats.sniperDamageUpgradePrice * 1.05); 
                PlayerStatsController.Stats.SniperDamage += (float)0.10;
                PlayerStatsController.Stats.Money -= Price;
                PlayerStatsController.Stats.Upgrades.Add(new SniperDamageUpgrade());
                return true;
            }

            return false;
        }
    }