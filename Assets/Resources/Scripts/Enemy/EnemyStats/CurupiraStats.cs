using UnityEngine;

public class CurupiraStats : EnemyStats
{
    public CurupiraStats()
    {
        baseHealth = 125 * Mathf.Pow(DifficultyStatsController.Stats.curupiraHealthIncrement, (WorldStatsController.Stats.DayCounter - 1));
        baseSpeed = 4f;
        baseAttackRange = 15f;
        baseAttackSpeed = 3f;
        baseAttackDamage = 10f;
    }
    
}
