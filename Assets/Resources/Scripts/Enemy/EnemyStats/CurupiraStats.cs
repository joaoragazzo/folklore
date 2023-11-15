using UnityEngine;

public class CurupiraStats : EnemyStats
{
    public CurupiraStats()
    {
        baseHealth = 125 * Mathf.Pow(DifficultyStatsController.Stats.curupiraHealthIncrement, (WorldStatsController.Stats.DayCounter - 1));
        baseSpeed = 5f;
        baseAttackRange = 25f;
        baseAttackSpeed = 5f;
        baseAttackDamage = 20f;
    }
    
}
