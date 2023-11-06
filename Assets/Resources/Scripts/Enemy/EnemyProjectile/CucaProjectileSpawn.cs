using UnityEngine;

public class CucaProjectileSpawn : MonoBehaviour
{
    private PlayerInteraction _playerInteraction;
    [SerializeField] private GameObject ammoPrefab; 

    void Start()
    {
        _playerInteraction = new PlayerInteraction();
        _playerInteraction.Initialize();
    }
    
    public void Attack()
    {
        Vector3 direction = (_playerInteraction.PlayerStats.PlayerPosition - transform.position).normalized;
        GameObject projectile = Instantiate(ammoPrefab, transform.position, Quaternion.LookRotation(_playerInteraction.PlayerStats.PlayerPosition));
        projectile.transform.LookAt(_playerInteraction.PlayerStats.PlayerPosition);
        projectile.GetComponent<Rigidbody>().velocity = direction * 40;
    }
}