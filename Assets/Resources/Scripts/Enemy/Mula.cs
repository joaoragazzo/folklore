using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mula : MonoBehaviour, IDamageble
{

    private MulaStats Stats;
    private EnemyMovement _enemyMovement;
    private bool isAttacking;
    private PlayerInteraction _playerInteraction;
    private Animator _animator;
    
    
    void Start()
    {
        _playerInteraction = new PlayerInteraction();
        _playerInteraction.Initialize();
        _animator = GetComponent<Animator>();
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

        if (isAttacking)
        {
            _animator.SetTrigger("Mula Attacking");
        }
        else if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Mula Running"))
        {
            _animator.Play("Mula Running");
        }
        
    }

    public void onAttack()
    {
        
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
