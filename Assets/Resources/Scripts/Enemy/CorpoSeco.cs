using System;
using UnityEditor;
using UnityEngine;

public class CorpoSeco : MonoBehaviour, IDamageble
{
    private bool alive = true;
    private bool isAttacking;
    private CorpoSecoStats    Stats;
    private EnemyMovement     _enemyMovement;
    private Animator          _animator;
    
    void Start()
    {
        
        Stats = new CorpoSecoStats();
        _enemyMovement = new EnemyMovement();
        _animator = GetComponent<Animator>();
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
    
    public void onZombieAttackEnd()
    {
        PlayerStatsController.Stats.ZombiesAttacking.Remove(this);
    }

    public void onZombieAttackBite()
    {
        PlayerStatsController.Stats.Health -= Stats.baseAttackDamage;
    }

    public void onZombieAttackBegin()
    {
        PlayerStatsController.Stats.ZombiesAttacking.Add(this);
    }

    public void onDie()
    {
        Destroy(gameObject);
    }
    
    public void TakeDamage(float amount)
    {
        PlayerStatsController.Stats.ZombiesAttacking.Remove(this);
        
        Stats.baseHealth -= amount;

        if (Stats.baseHealth <= 0)
        {
            alive = false;
            _animator.SetTrigger("Die");
        }
        
    }
}
