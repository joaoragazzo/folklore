using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurupiraProjectile : MonoBehaviour
{
    private CurupiraStats _stats;
    private float lifeDuration = 5f;
    

    public void Start()
    {
        
        Destroy(gameObject, lifeDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _stats = new CurupiraStats(new WorldInteraction());
            PlayerInteraction playerInteraction = new PlayerInteraction();
            playerInteraction.Initialize();
            
            playerInteraction.PlayerStats.Health -= _stats.baseAttackDamage;
            Destroy(gameObject);
        }

        if (other.CompareTag("Tree") || other.CompareTag("Ground"))
        {  
            Destroy(gameObject);
        }
    }
}
