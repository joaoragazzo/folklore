using System;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void Update()
    {
        if (PlayerStatsController.Stats.isAttackingWithAxe) return;

        if (!PlayerStatsController.Stats.IsAlive)
        {
            _animator.SetTrigger("isDead");
        }
        
        _animator.SetBool("isMoving", PlayerStatsController.Stats.IsMoving);
        
        Vector3 worldVelocity = PlayerStatsController.Stats.PlayerVelocity;
        Vector3 localVelocity = transform.InverseTransformDirection(worldVelocity);
        float forwardSpeed = localVelocity.z / PlayerStatsController.Stats.WalkSpeed;
        
        forwardSpeed = Mathf.Clamp(forwardSpeed, -1f, 1f);

        _animator.SetFloat("VelocityW", forwardSpeed);

        worldVelocity = PlayerStatsController.Stats.PlayerVelocity;
        localVelocity = transform.InverseTransformDirection(worldVelocity);
        forwardSpeed = localVelocity.x / PlayerStatsController.Stats.WalkSpeed;
        forwardSpeed = Mathf.Clamp(forwardSpeed, -1f, 1f);

        _animator.SetFloat("VelocityS", forwardSpeed);

        if (Input.GetButtonDown("Fire2") && !PlayerStatsController.Stats.isAttackingWithAxe)
        {
            _animator.SetTrigger("isAxeAttacking");
        }
        
    }

    public void onAttackBegin()
    {
        PlayerStatsController.Stats.isAttackingWithAxe = true;
        CheckObjectsInBoxCollider();
    }

    public void onAttackEnd()
    {
        PlayerStatsController.Stats.isAttackingWithAxe = false;
    }

    public void onDieAnimationEnd()
    {
        
    }

    void CheckObjectsInBoxCollider()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        // O centro e o tamanho do boxCollider
        Vector3 center = transform.TransformPoint(boxCollider.center);
        Vector3 halfExtents = boxCollider.size * 2;

        // Encontrar todos os colisores dentro do box
        Collider[] hitColliders = Physics.OverlapBox(center, halfExtents, transform.rotation);

        // Iterar pelos colisores encontrados
        foreach (var hitCollider in hitColliders)
        {
            try
            {
                IDamageble entity = hitCollider.GetComponent<IDamageble>();
                entity.TakeDamage(PlayerStatsController.Stats.Strength);
            } catch (Exception e)
            {
                continue;
            }
        }
    }
    
}