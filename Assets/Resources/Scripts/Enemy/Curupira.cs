
using UnityEngine;

public class Curupira : MonoBehaviour, IDamageble
{
    [SerializeField]
    private AudioClip audioClip; // Permitir atribuir um AudioClip no Inspector
    private AudioSource audioSource;
    private bool alive = true;
    private bool isAttacking;
    private CurupiraStats Stats;
    private EnemyMovement _enemyMovement;
    private Animator _animator;
    private CurupiraProjectileSpawn attackScript;
    
    void Start()
    {
        Invoke("safeDestroy", GameStatsController.Stats.maxTimeForEntities);
        attackScript = transform.Find("CharacterArmature/Root/Body/Hips/Abdomen/Torso/Chest/Shoulder.R/UpperArm.R/LowerArm.R/Wrist.R/Middle1.R/Crossbow/AttackSpawn").GetComponent<CurupiraProjectileSpawn>();
        _animator = GetComponent<Animator>();
        Stats = new CurupiraStats();
        _enemyMovement = new EnemyMovement();
        audioSource = GetComponent<AudioSource>();
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
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip); // Toca o áudio especificado
        }
        attackScript.Attack();
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
            _animator.SetTrigger("Die");
            alive = false;
        }
    }
    
    public void safeDestroy()
    {
        WorldStatsController.Stats.enemiesExisting--;
        Destroy(gameObject);
    }
}
