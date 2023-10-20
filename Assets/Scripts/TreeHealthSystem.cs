using System.Collections;
using UnityEngine;

public class TreeHealthSystem : MonoBehaviour, IDamageble
{
    private PlayerInteraction playerInteraction = new PlayerInteraction();
    
    private int health = 3;
    private float shakeDuration = 0.5f;
    private float shakeMagnitude = 0.1f;
    public float fallDuration = 2.0f;
    public float fadeDuration = 2.0f; // Duração da animação de desaparecimento

    private Collider treeCollider;

    private void Awake()
    {
        treeCollider = GetComponent<Collider>();
    }

    public void TakeDamage(int damage)
    {
        health -= 1;
        
        StartCoroutine(Shake());
        
        if (health == 0)
        {
            float randomAngle = (Random.value > 0.5f) ? -10f : -180f;
            StartCoroutine(FallOver(randomAngle));
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
        playerInteraction.PlayerStats.Money += 3;
        
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

        // Desativar colisão e iniciar animação de desaparecimento
        treeCollider.enabled = false;
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
