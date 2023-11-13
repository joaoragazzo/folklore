using UnityEngine;

    public class SniperDroneUpgrade : Upgrade
    {

        public SniperDroneUpgrade()
        {

            Name = "Drone de Sniper";
            Description = "Habilita um drone com Sniper";
            Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
            Price = 0;
            Max = 1;
        }
        public override bool ApplyUpgrade()
        {
            if (PlayerStatsController.Stats.Money >= Price)
            {
                SniperDroneController.droneAlive = true;
                PlayerStatsController.Stats.Money -= Price;
                return true;
            }

            return false;
        }
    }