using UnityEngine;

public class SaciStats : EnemyStats
{
    private WorldInteraction _worldInteraction;
    
    public SaciStats(WorldInteraction worldInteraction)
    {
        _worldInteraction = worldInteraction;
        _worldInteraction.Initialize();
        
        baseHealth = 150  * Mathf.Pow(1.05f, (_worldInteraction.worldStats.DayCounter - 1));
        baseSpeed = 5f;
        baseAttackSpeed = 2f;
        baseAttackRange = 3f;
        baseAttackDamage = 15f;
    }
    
}