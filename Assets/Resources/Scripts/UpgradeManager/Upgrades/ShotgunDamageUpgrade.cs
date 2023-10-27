using UnityEngine;

namespace Resources.Scripts.UpgradeManager.Upgrades
{
    public class ShotgunDamageUpgrade : Upgrade
    {
        private PlayerInteraction playerInteraction;

        public ShotgunDamageUpgrade()
        {
            playerInteraction = new PlayerInteraction();
            playerInteraction.Initialize();

            Name = "Dano da Shotgun";
            Description = "Dano da Shotgun +10%";
            Image = (Sprite)UnityEngine.Resources.Load("Images/Upgrades/critdamageupgrade");
            Price = 10;
            Max = 500;
        }

        public override bool ApplyUpgrade()
        {
            if (playerInteraction.PlayerStats.Money >= Price)
            {
                playerInteraction.PlayerStats.ShotgunDamage += (float)0.10;
                playerInteraction.PlayerStats.Money -= Price;
                return true;
            }

            return false;
        }
    }
}