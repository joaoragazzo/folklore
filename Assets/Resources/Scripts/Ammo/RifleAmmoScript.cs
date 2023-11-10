using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAmmoScript : MonoBehaviour
{
    private Rigidbody ammoRigidbody;
    public float lifeDuration = 5;
    public double damage;
    public static bool droneTreeDamageUpgrade = false;
    
    private void Awake()
    {
        ammoRigidbody = GetComponent<Rigidbody>();
    }

// Start is called before the first frame update
    void Start()
    {
        damage = PlayerStatsController.Stats.RifleDamage;
        float speed = 150f;
        ammoRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, lifeDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")) // Verifica se o objeto atingido tem a tag "Enemy"
        {
            IDamageble damageableEntity = other.GetComponent<IDamageble>();
            damageableEntity.TakeDamage((float)PlayerStatsController.Stats.RifleDamage);
            Destroy(gameObject);
        }
        
        if((other.CompareTag("Tree") && !droneTreeDamageUpgrade) || other.CompareTag("Ground")) // Verifica se o objeto atingido tem a tag "Enemy"
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Tree") && droneTreeDamageUpgrade)
        {
            IDamageble damageableEntity = other.GetComponent<IDamageble>();
            damageableEntity.TakeDamage((float)0.3);
            Destroy(gameObject);
        }
    }
}
