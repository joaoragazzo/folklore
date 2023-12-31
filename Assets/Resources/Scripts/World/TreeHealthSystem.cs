using System.Collections;
using UnityEngine;

public class TreeHealthSystem : MonoBehaviour, IDamageble
{
    [SerializeField] private AudioSource treeFalling;
    private float health = 3;
    private float shakeDuration = 0.5f;
    private float shakeMagnitude = 0.1f;
    public float fallDuration = 2.0f;
    public float fadeDuration = 2.0f; // Duração da animação de desaparecimento
    private bool dead = false;
    
    private Collider treeCollider;

    private void Awake()
    {
        treeCollider = GetComponent<Collider>();
    }


    
    public void TakeDamage(float damage)
    {
        Debug.Log(PlayerStatsController.Stats.Strength);
        health -= PlayerStatsController.Stats.Strength;
        
        StartCoroutine(Shake());
        
        if (health <= 0 && !dead)
        {
            dead = true;
            PlayerStatsController.Stats.Money += 3;
            float randomAngle = (Random.value > 0.5f) ? -10f : -180f;
            StartCoroutine(FallOver(randomAngle));
            if(dead && !treeFalling.isPlaying) 
            {
                treeFalling.Play();
            }
        }
    }
    
    private IEnumerator Shake()
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }

    private IEnumerator FallOver(float targetAngle)
    {
        treeCollider.enabled = false;
        
        float elapsed = 0.0f;
        Quaternion initialRotation = transform.rotation;
        Quaternion finalRotation = Quaternion.Euler(targetAngle, 0, 0);

        while (elapsed < fallDuration)
        {
            transform.rotation = Quaternion.Lerp(initialRotation, finalRotation, elapsed / fallDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = finalRotation;
        
        StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator FadeOutAndDestroy()
    {
        float elapsed = 0.0f;
        Renderer[] treeRenderers = GetComponentsInChildren<Renderer>();

        while (elapsed < fadeDuration)
        {
            float cutoff = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
        
            foreach (var renderer in treeRenderers)
            {
                if (renderer.material.HasProperty("_Cutoff"))
                {
                    renderer.material.SetFloat("_Cutoff", cutoff);
                }
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
