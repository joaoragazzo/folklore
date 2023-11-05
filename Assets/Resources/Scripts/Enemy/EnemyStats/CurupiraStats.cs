using UnityEngine;

public class CurupiraStats : EnemyStats
{
    private WorldInteraction _worldInteraction = new WorldInteraction();
    
    public CurupiraStats()
    {
        _worldInteraction.Initialize();
        baseHealth = 125 * Mathf.Pow(1.05f, (_worldInteraction.worldStats.DayCounter - 1));
        baseSpeed = 5f;
        baseAttackRange = 25f;
        baseAttackSpeed = 5f;
        baseAttackDamage = 20f;
    }
    
}
