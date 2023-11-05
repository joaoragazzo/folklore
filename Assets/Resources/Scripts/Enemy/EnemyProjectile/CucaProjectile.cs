using UnityEngine;

public class CucaProjectile : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerInteraction _playerInteraction;
    private float lifeDuration = 5f;
    private float damage;

    public CucaProjectile(float damage)
    {
        this.damage = damage;
    }
}

