using UnityEngine;

    public class ShotgunDroneUpgrade : Upgrade
    {

        public ShotgunDroneUpgrade()
        {

            Name = "Drone de Shotgun";
            Description = "Habilita um drone com Shotgun";
            Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
            Price = 0;
            Max = 1;
        }
        public override bool ApplyUpgrade()
        {
            if (PlayerStatsController.Stats.Money >= Price)
            {
                ShotgunDroneController.droneAlive = true;
                PlayerStatsController.Stats.Money -= Price;
                return true;
            }

            return false;
        }
    }