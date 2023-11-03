using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mula : MonoBehaviour, IDamageble
{

    private MulaStats Stats;
    private EnemyMovement _enemyMovement;
    private bool isAttacking;
    
    
    void Start()
    {
        Stats = new MulaStats();
        _enemyMovement = new EnemyMovement();
    }

    void Update()
    {
        (transform.position, transform.rotation, isAttacking) = _enemyMovement.newPosition(
            transform.position,
            Stats.baseSpeed,
            Stats.baseAttackRange,
            isAttacking
        );
    }
    
    public void TakeDamage(int amount)
    {
        Stats.baseHealth -= amount;

        if (Stats.baseHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
