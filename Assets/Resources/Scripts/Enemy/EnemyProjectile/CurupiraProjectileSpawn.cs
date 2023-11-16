
using UnityEngine;

public class CurupiraProjectileSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ammoPrefab; 
    
    
    public void Attack()
    {
        Vector3 direction = (PlayerStatsController.Stats.PlayerPosition - transform.position).normalized;
        GameObject projectile = Instantiate(ammoPrefab, transform.position, Quaternion.LookRotation(PlayerStatsController.Stats.PlayerPosition));
        projectile.transform.LookAt(PlayerStatsController.Stats.PlayerPosition);
        projectile.GetComponent<Rigidbody>().velocity = direction * 125;
    }
}
