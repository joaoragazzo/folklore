using UnityEngine;
    public class ShotgunDamageUpgrade : Upgrade
    {

        public ShotgunDamageUpgrade()
        {

            Name = "Dano da Shotgun";
            Description = "Dano da Shotgun +10%";
            Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
            Price = 10;
            Max = 500;
        }

        public override bool ApplyUpgrade()
        {
            if (PlayerStatsController.Stats.Money >= Price)
            {
                PlayerStatsController.Stats.ShotgunDamage += (float)0.10;
                PlayerStatsController.Stats.Money -= Price;
                return true;
            }

            return false;
        }
    }