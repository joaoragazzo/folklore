using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuca : MonoBehaviour, IDamageble
{
    private bool alive = true;
    private CucaStats Stats;
    private EnemyMovement _enemyMovement;
    private bool isAttacking;
    private PlayerInteraction _playerInteraction;
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerInteraction = new PlayerInteraction();
        _playerInteraction.Initialize();
        Stats = new CucaStats();
        _enemyMovement = new EnemyMovement();
    }

    void Update()
    {
        if (alive) (transform.position, transform.rotation, isAttacking) = _enemyMovement.newPosition(
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

    public void onAttack()
    {
        
    }

    public void onDie()
    {
        Destroy(gameObject);
    }
    
    public void TakeDamage(int amount)
    {
        Stats.baseHealth -= amount;

        if (Stats.baseHealth <= 0)
        {
            alive = false;
            _animator.SetTrigger("Die");
        }
    }
}
