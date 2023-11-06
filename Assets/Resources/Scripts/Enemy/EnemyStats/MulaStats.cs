using UnityEngine;

public class MulaStats : EnemyStats
{
    private WorldInteraction _worldInteraction;
    
    public MulaStats(WorldInteraction worldInteraction)
    {
        _worldInteraction = worldInteraction;
        _worldInteraction.Initialize();
        
        baseHealth = 250 * Mathf.Pow(1.05f, (_worldInteraction.worldStats.DayCounter - 1));
        baseSpeed = 10f;
        baseAttackDamage = 25f;
        baseAttackRange = 7f;
        baseAttackSpeed = 2f;
    }
    
}
