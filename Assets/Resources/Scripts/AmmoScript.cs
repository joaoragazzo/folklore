using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    private Rigidbody ammoRigidbody;

    private void Awake()
    {
        ammoRigidbody = GetComponent<Rigidbody>();
    }

// Start is called before the first frame update
    void Start()
    {
        float speed = 10f;
        ammoRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")) // Verifica se o objeto atingido tem a tag "Enemy"
        {
            Destroy(gameObject);
        }
        
        if(other.CompareTag("Tree")) // Verifica se o objeto atingido tem a tag "Enemy"
        {
            Destroy(gameObject);
        }
        
        if(other.CompareTag("Ground")) // Verifica se o objeto atingido tem a tag "Enemy"
        {
            Destroy(gameObject);
        }
    }
}
