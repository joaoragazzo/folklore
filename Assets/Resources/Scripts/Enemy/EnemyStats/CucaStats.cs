using UnityEngine;

public class CucaStats : EnemyStats
{
    public CucaStats()
    {
        baseHealth = 100 * Mathf.Pow(1.05f, (WorldStatsController.Stats.DayCounter - 1));
        baseSpeed = 5.0f;
        baseAttackDamage = 10;
        baseAttackRange = 10f;
        baseAttackSpeed = 1f;
    }
}
