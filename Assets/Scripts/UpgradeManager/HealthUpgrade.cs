using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strengthgrade : Upgrade
{
    public PlayerInteraction playerInteraction;
<<<<<<< Updated upstream

    public HealthUpgrade()
=======
    
    public Strengthgrade()
>>>>>>> Stashed changes
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();

        Name = "Força";
        Description = "Aumenta sua força em +1";
        Image = Resources.Load<Sprite>("Images/Upgrades/treedamageupgradeicon");
        Price = 35;
    }

<<<<<<< Updated upstream
    public override bool ApplyUpgrade()
    {
        if (playerInteraction.PlayerStats.Money >= 35)
        {
            playerInteraction.PlayerStats.Strength += 1;
            playerInteraction.PlayerStats.Money -= 35;
            return true;
        }
        
        return false;
=======
    public override void ApplyUpgrade(PlayerStats playerstats)
    {
        playerstats.MaxHealth = playerstats.Strength + 1;
>>>>>>> Stashed changes
    }
}
    
