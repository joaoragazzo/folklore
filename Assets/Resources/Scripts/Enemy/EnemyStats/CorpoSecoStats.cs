
using UnityEngine;

public class CorpoSecoStats: EnemyStats
{
    private WorldInteraction _worldInteraction;
    
    public CorpoSecoStats(WorldInteraction worldInteraction)
    {
        _worldInteraction = worldInteraction;
        _worldInteraction.Initialize();
        
        baseHealth = 400 * Mathf.Pow(1.05f, (_worldInteraction.worldStats.DayCounter - 1));
        baseSpeed = 1.5f;
        baseAttackDamage = 33f;
        baseAttackRange = 3f;
        baseAttackSpeed = 0.5f;
    }
    
}
