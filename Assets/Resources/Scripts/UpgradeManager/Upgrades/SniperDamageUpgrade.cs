using System;
using UnityEngine;

    public class SniperDamageUpgrade : Upgrade
    {
        private PlayerInteraction playerInteraction;

        public SniperDamageUpgrade()
        {
            playerInteraction = new PlayerInteraction();
            playerInteraction.Initialize();

            Name = "Dano da Sniper";
            Description = "Dano da Sniper +10%";
            Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
            Price = 20;
            Max = 500;
        }

        public override bool ApplyUpgrade()
        {
            if (playerInteraction.PlayerStats.Money >= Price)
            {
                playerInteraction.PlayerStats.SniperDamage += (float)0.10;
                playerInteraction.PlayerStats.Money -= Price;
                return true;
            }

            return false;
        }
    }