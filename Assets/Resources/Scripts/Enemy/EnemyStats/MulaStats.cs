using UnityEngine;

public class MulaStats : EnemyStats
{
    public MulaStats()
    {
        baseHealth = 300 * Mathf.Pow(DifficultyStatsController.Stats.mulaHealthIncrement, (WorldStatsController.Stats.DayCounter - 1));
        baseSpeed = 12f;
        baseAttackDamage = 25f;
        baseAttackRange = 6f;
        baseAttackSpeed = 2f;
    }
    
}
