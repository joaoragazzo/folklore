using UnityEngine;

    public class RifleDamageUpgrade : Upgrade
    {
        private PlayerInteraction playerInteraction;

        public RifleDamageUpgrade()
        {
            playerInteraction = new PlayerInteraction();
            playerInteraction.Initialize();

            Name = "Dano do Rifle";
            Description = "Dano do Rifle +10%";
            Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
            Price = 6;
            Max = 500;
        }
        public override bool ApplyUpgrade()
        {
            if (playerInteraction.PlayerStats.Money >= Price)
            {
                playerInteraction.PlayerStats.RifleDamage += (float)0.10;
                playerInteraction.PlayerStats.Money -= Price;
                return true;
            }

            return false;
        }
    }