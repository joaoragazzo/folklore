using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.UI;
using UnityEngine;

public class Saci : MonoBehaviour, IDamageble
{
    private SaciStats Stats;
    private EnemyMovement _enemyMovement;
    private bool isAttacking;

    void Start()
    {
        Stats = new SaciStats();
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
