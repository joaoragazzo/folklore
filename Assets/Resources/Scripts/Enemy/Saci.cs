using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.UI;
using UnityEngine;

public class Saci : MonoBehaviour, IDamageble
{
    private SaciStats Stats;
    private EnemyMovement _enemyMovement;
    private bool isAttacking;
    private PlayerInteraction _playerInteraction;
    private Animator _animator;

    void Start()
    {
        _playerInteraction = new PlayerInteraction();
        _playerInteraction.Initialize();
        _animator = GetComponent<Animator>();
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

        if (isAttacking)
        {
            _animator.SetTrigger("Saci Attacking");
        }
        else
        {
            _animator.Play("Saci Running");
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
