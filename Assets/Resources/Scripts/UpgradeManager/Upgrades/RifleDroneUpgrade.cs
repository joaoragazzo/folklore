using UnityEngine;

    public class RifleDroneUpgrade : Upgrade
    {

        public RifleDroneUpgrade()
        {

            Name = "Drone de Rifle";
            Description = "Habilita um drone com Rifle";
            Image = Resources.Load<Sprite>("Images/Upgrades/critdamageupgrade");
            Price = 0;
            Max = 1;
        }
        public override bool ApplyUpgrade()
        {
            if (PlayerStatsController.Stats.Money >= Price)
            {
                RifleDroneController.droneAlive = true;
                PlayerStatsController.Stats.Money -= Price;
                return true;
            }

            return false;
        }
    }