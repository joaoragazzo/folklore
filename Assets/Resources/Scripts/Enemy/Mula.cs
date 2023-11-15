using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mula : MonoBehaviour, IDamageble
{
    private bool alive = true;
    private bool isAttacking;
    private MulaStats Stats;
    private EnemyMovement _enemyMovement;
    private Animator _animator;
    
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        Stats = new MulaStats();
        _enemyMovement = new EnemyMovement();
    }

    void Update()
    {
        if (WorldStatsController.Stats.IsPaused) return;
        
        if (alive) (transform.position, transform.rotation, isAttacking) = _enemyMovement.newPosition(
            transform.position,
            Stats.baseSpeed,
            Stats.baseAttackRange
        );

        if (isAttacking)
        {  
            _animator.SetTrigger("Attack");
        }
        else
        {
            _animator.SetTrigger("Walk");
        }
        
    }

    public void onAttack()
    {
        PlayerStatsController.Stats.Health -= Stats.baseAttackDamage;
    }

    public void onDie()
    {
        WorldStatsController.Stats.enemiesExisting--;
        Destroy(gameObject); 
    }
    
    public void TakeDamage(float amount)
    {
        Stats.baseHealth -= amount;

        if (Stats.baseHealth <= 0)
        {
            alive = false;
            _animator.SetTrigger("Die");
        }
    }
}
