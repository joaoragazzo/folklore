using System;
using UnityEditor;
using UnityEngine;

public class CorpoSeco : MonoBehaviour, IDamageble
{
    private CorpoSecoStats Stats;
    private EnemyMovement _enemyMovement;
    private bool isAttacking;
    private Animator _animator;
    private PlayerInteraction _playerInteraction;
    
    
    void Start()
    {
        _playerInteraction = new PlayerInteraction();
        _playerInteraction.Initialize();
        Stats = new CorpoSecoStats();
        _enemyMovement = new EnemyMovement();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        (transform.position, transform.rotation, isAttacking) = _enemyMovement.newPosition(
            transform.position,
            Stats.baseSpeed,
            Stats.baseAttackRange,
            isAttacking
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
        _playerInteraction.PlayerStats.ZombiesAttacking.Remove(this);
    }

    public void onZombieAttackBite()
    {
        _playerInteraction.PlayerStats.Health -= Stats.baseAttackDamage;
    }

    public void onZombieAttackBegin()
    {
        _playerInteraction.PlayerStats.ZombiesAttacking.Add(this);
    }
    
    public void TakeDamage(int amount)
    {
        _playerInteraction.PlayerStats.ZombiesAttacking.Remove(this);
        
        Stats.baseHealth -= amount;

        if (Stats.baseHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
