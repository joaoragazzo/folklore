using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curupira : MonoBehaviour, IDamageble
{
    private bool alive = true;
    private CurupiraStats Stats;
    private EnemyMovement _enemyMovement;
    private bool isAttacking;
    private PlayerInteraction _playerInteraction;
    private Animator _animator;
    private CurupiraProjectileSpawn attackScript;
    
    void Start()
    {
        attackScript = transform.Find("CharacterArmature/Root/Body/Hips/Abdomen/Torso/Chest/Shoulder.R/UpperArm.R/LowerArm.R/Wrist.R/Middle1.R/Crossbow/AttackSpawn").GetComponent<CurupiraProjectileSpawn>();
        _playerInteraction = new PlayerInteraction();
        _animator = GetComponent<Animator>();
        Stats = new CurupiraStats(new WorldInteraction());
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
        attackScript.Attack();
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
            _animator.SetTrigger("Die");
            alive = false;
        }
    }
}
