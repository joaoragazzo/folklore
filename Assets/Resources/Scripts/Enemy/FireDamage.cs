using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public float damageInterval = 0.001f; // Dano causado a cada segundo (pode ser ajustado)
    private bool isPlayerInTrigger = false;
    public float damage = 0.3f;
    void Update()
    {
        if (isPlayerInTrigger)
        {
            StartCoroutine(DamagePlayer());
        }
    }

    private IEnumerator DamagePlayer()
    {
        isPlayerInTrigger = false; // Desativamos isso para evitar múltiplas corrotinas correndo ao mesmo tempo
        PlayerStatsController.Stats.TakeDamage(damage);
        yield return new WaitForSeconds(damageInterval);
        isPlayerInTrigger = true; // Reativamos após o intervalo
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            StopCoroutine(DamagePlayer());
        }
    }
}