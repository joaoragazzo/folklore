
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
            _stats = new CurupiraStats();
            
            PlayerStatsController.Stats.Health -= _stats.baseAttackDamage;
            Destroy(gameObject);
        }

        if (other.CompareTag("Tree") || other.CompareTag("Ground"))
        {  
            Destroy(gameObject);
        }
    }
}
