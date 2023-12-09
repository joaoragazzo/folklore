using UnityEngine;

public class CucaProjectileSpawn : MonoBehaviour
{

    [SerializeField]
    private AudioClip audioClip; // Permitir atribuir um AudioClip no Inspector
    private AudioSource audioSource;
    [SerializeField] private GameObject ammoPrefab; 
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        Vector3 direction = (PlayerStatsController.Stats.PlayerPosition - transform.position).normalized;
        GameObject projectile = Instantiate(ammoPrefab, transform.position, Quaternion.LookRotation(PlayerStatsController.Stats.PlayerPosition));
        projectile.transform.LookAt(PlayerStatsController.Stats.PlayerPosition);
        projectile.GetComponent<Rigidbody>().velocity = direction * 40;
        if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip); // Toca o áudio especificado
            }
    }
}