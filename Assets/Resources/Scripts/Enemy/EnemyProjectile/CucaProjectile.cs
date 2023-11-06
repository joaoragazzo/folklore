using System;
using UnityEngine;

public class CucaProjectile : MonoBehaviour
{
    private CucaStats _stats;
    private float lifeDuration = 5f;
    

    public void Start()
    {
        
        Destroy(gameObject, lifeDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _stats = new CucaStats(new WorldInteraction());
            PlayerStatsController.Stats.Health -= _stats.baseAttackDamage;
            Destroy(gameObject);
        }

        if (other.CompareTag("Tree") || other.CompareTag("Ground"))
        {  
            Destroy(gameObject);
        }
    }
    
}

