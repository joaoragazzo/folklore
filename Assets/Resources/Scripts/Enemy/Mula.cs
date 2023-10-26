using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mula : MonoBehaviour, IDamageble
{

    private MulaStats Stats;
    private EnemyMovement _enemyMovement;
    
    
    void Start()
    {
        Stats = new MulaStats();
        _enemyMovement = new EnemyMovement();
    }

    void Update()
    {
        (transform.position, transform.rotation) = _enemyMovement.newPosition(
            transform.position,
            Stats.baseSpeed,
            Stats.baseAttackRange
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
