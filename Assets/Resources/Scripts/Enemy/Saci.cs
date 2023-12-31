using UnityEngine;

public class Saci : MonoBehaviour, IDamageble
{
    private bool alive = true;
    private bool isAttacking;
    private SaciStats Stats;
    private EnemyMovement _enemyMovement;
    private PlayerStatsController _player;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        Stats = new SaciStats();
        _enemyMovement = new EnemyMovement();
    }

    void Update()
    {
        Invoke("safeDestroy", GameStatsController.Stats.maxTimeForEntities);
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
    
    public void safeDestroy()
    {
        WorldStatsController.Stats.enemiesExisting--;
        Destroy(gameObject);
    }
}
