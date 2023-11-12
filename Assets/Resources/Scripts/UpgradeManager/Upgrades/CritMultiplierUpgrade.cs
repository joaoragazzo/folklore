using UnityEngine;

    public class CritDamageMultiplier : Upgrade
    {

        public CritDamageMultiplier()
        {
            Name = "Dano Crítico";
            Description = "Dano Crítico +10";
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
                PlayerStatsController.Stats.Upgrades.Add(new CritDamageMultiplier());
                return true;
            }

            return false;
        }
    }