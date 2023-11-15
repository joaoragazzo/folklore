using UnityEngine;

public class MulaStats : EnemyStats
{
    public MulaStats()
    {
        baseHealth = 250 * Mathf.Pow(DifficultyStatsController.Stats.mulaHealthIncrement, (WorldStatsController.Stats.DayCounter - 1));
        baseSpeed = 10f;
        baseAttackDamage = 25f;
        baseAttackRange = 7f;
        baseAttackSpeed = 2f;
    }
    
}
