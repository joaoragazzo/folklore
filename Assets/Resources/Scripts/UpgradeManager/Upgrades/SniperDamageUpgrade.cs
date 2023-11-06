using System;
using UnityEngine;

    public class SniperDamageUpgrade : Upgrade
    {

        public SniperDamageUpgrade()
        {
            Name = "Dano da Sniper";
            Description = "Dano da Sniper +10%";
            Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
            Price = 20;
            Max = 500;
        }

        public override bool ApplyUpgrade()
        {
            if (PlayerStatsController.Stats.Money >= Price)
            {
                PlayerStatsController.Stats.SniperDamage += (float)0.10;
                PlayerStatsController.Stats.Money -= Price;
                return true;
            }

            return false;
        }
    }