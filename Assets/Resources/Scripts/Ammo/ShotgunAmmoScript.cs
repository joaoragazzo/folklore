using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmoScript : MonoBehaviour
{
    private Rigidbody ammoRigidbody;
    public float lifeDuration = 5;
    public double damage;
    
    
    private void Awake()
    {
        ammoRigidbody = GetComponent<Rigidbody>();
    }

// Start is called before the first frame update
    void Start()
    {
        damage = PlayerStatsController.Stats.ShotgunDamage;
        float speed = 150f;
        ammoRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, lifeDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")) // Verifica se o objeto atingido tem a tag "Enemy"
        {
            IDamageble damageableEntity = other.GetComponent<IDamageble>();
            damageableEntity.TakeDamage((int)damage);
            Destroy(gameObject);
        }
        
        if(other.CompareTag("Tree") || other.CompareTag("Ground")) // Verifica se o objeto atingido tem a tag "Enemy"
        {
            Destroy(gameObject);
        }
    }
}
