using UnityEngine;

    public class RifleDamageUpgrade : Upgrade
    {

        public RifleDamageUpgrade()
        {

            Name = "Dano do Rifle";
            Description = "Dano do Rifle +10";
            Image = Resources.Load<Sprite>("Images/Upgrades/AK47");
            Price = 6;
            UpgradeIncrement = 10;
            Max = 500;
        }
        public override bool ApplyUpgrade()
        {
            if (PlayerStatsController.Stats.Money >= Price)
            {
                PlayerStatsController.Stats.RifleDamage += (float)0.10;
                PlayerStatsController.Stats.Money -= Price;
                PlayerStatsController.Stats.Upgrades.Add(new RifleDamageUpgrade());
                return true;
            }

            return false;
        }
    }