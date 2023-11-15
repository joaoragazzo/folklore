using UnityEngine;

public class CorpoSecoStats: EnemyStats
{
    public CorpoSecoStats()
    {
        baseHealth = 400 * Mathf.Pow(DifficultyStatsController.Stats.corpoSecoHealthIncrement, (WorldStatsController.Stats.DayCounter - 1));
        baseSpeed = 1.5f;
        baseAttackDamage = 33f;
        baseAttackRange = 3f;
        baseAttackSpeed = 0.5f;
    }
    
}
