using UnityEngine;

    public class CritMultiplierUpgrade : Upgrade
    {

        public CritMultiplierUpgrade()
        {

            Name = "Dano Crítico";
            Description = "Dano Crítico +10%";
            Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
            Price = 30;
            Max = 10;
        }

        public override bool ApplyUpgrade()
        {
            if (PlayerStatsController.Stats.Money >= Price)
            {
                PlayerStatsController.Stats.CritMultiplier += (float)0.10;
                PlayerStatsController.Stats.Money -= Price;
                return true;
            }

            return false;
        }
    }