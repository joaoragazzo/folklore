using System;
using UnityEngine;

public class CucaProjectile : MonoBehaviour
{
    private CucaStats _stats;
    private Rigidbody _rigidbody;
    private PlayerInteraction _playerInteraction;
    private float lifeDuration = 5f;
    private float damage;

    public void Awake()
    {
        _stats = new CucaStats(new WorldInteraction());
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        _rigidbody.velocity = Vector3.forward * 75f;
    }
}

