using UnityEngine;

    public class CritMultiplierUpgrade : Upgrade
    {
        private PlayerInteraction playerInteraction;

        public CritMultiplierUpgrade()
        {
            playerInteraction = new PlayerInteraction();
            playerInteraction.Initialize();

            Name = "Dano Crítico";
            Description = "Dano Crítico +10%";
            Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
            Price = 30;
            Max = 10;
        }

        public override bool ApplyUpgrade()
        {
            if (playerInteraction.PlayerStats.Money >= Price)
            {
                playerInteraction.PlayerStats.CritMultiplier += (float)0.10;
                playerInteraction.PlayerStats.Money -= Price;
                return true;
            }

            return false;
        }
    }