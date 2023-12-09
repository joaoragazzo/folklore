
using UnityEngine;

public class DroneAttackShotgun : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip; // Permitir atribuir um AudioClip no Inspector
    private AudioSource audioSource; //Necessário pra execução do áudio
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float nextTimeToFire = 2f;
    [SerializeField] private LayerMask mouseColliderMask;

    public int pelletsCount = 8; // Quantos projéteis por disparo.
    public float spreadAngle = 20f; // ângulo de dispersão dos projéteis.

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderMask))
        {
            Vector3 aimDir = (raycastHit.point - transform.position).normalized;
            if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && PlayerStatsController.Stats.CanFire)
            {
                for (int i = 0; i < pelletsCount; i++)
                {
                    FirePellet(aimDir, spreadAngle);
                }

                nextTimeToFire = Time.time + 1f/fireRate;
                
                if (audioClip != null)
                {
                    audioSource.PlayOneShot(audioClip); // Toca o áudio especificado
                }
            }
        }
    }

    void FirePellet(Vector3 aimDir, float spread)
    {
        // Gera um desvio aleatório para a direção do projétil.
        Vector3 spreadVector = Random.insideUnitCircle * Mathf.Tan(spread * Mathf.Deg2Rad);
        Vector3 perturbedAimDir = Quaternion.LookRotation(aimDir) * new Vector3(spreadVector.x, spreadVector.y, 1f);

        // Instancia o projétil com a direção perturbada.
        Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(perturbedAimDir));
    }
}
