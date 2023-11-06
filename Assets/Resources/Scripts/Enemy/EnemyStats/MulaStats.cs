using UnityEngine;

public class MulaStats : EnemyStats
{
    public MulaStats()
    {
        baseHealth = 250 * Mathf.Pow(1.05f, (WorldStatsController.Stats.DayCounter - 1));
        baseSpeed = 10f;
        baseAttackDamage = 25f;
        baseAttackRange = 7f;
        baseAttackSpeed = 2f;
    }
    
}
