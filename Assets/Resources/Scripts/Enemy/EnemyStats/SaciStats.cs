using UnityEngine;

public class SaciStats : EnemyStats
{
    
    public SaciStats()
    {
        baseHealth = 150  * Mathf.Pow(DifficultyStatsController.Stats.saciHealthIncrement, (WorldStatsController.Stats.DayCounter - 1));
        baseSpeed = 5f;
        baseAttackSpeed = 2f;
        baseAttackRange = 3f;
        baseAttackDamage = 15f;
    }
    
}