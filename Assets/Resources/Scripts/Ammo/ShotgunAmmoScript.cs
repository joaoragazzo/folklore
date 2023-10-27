using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmoScript : MonoBehaviour
{
    private Rigidbody ammoRigidbody;
    private PlayerInteraction playerInteraction;
    public float lifeDuration = 5;
    public int damage;
    
    
    private void Awake()
    {
        ammoRigidbody = GetComponent<Rigidbody>();
    }

// Start is called before the first frame update
    void Start()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();
        damage = playerInteraction.PlayerStats.ShotgunDamage;
        float speed = 150f;
        ammoRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, lifeDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")) // Verifica se o objeto atingido tem a tag "Enemy"
        {
            IDamageble damageableEntity = other.GetComponent<IDamageble>();
            damageableEntity.TakeDamage(damage);
            Destroy(gameObject);
        }
        
        if(other.CompareTag("Tree") || other.CompareTag("Ground")) // Verifica se o objeto atingido tem a tag "Enemy"
        {
            Destroy(gameObject);
        }
    }
}
