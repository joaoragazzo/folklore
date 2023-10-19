using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuca : MonoBehaviour, IDamageble
{
    public static float health = 100f;
    public static float critChance = 0.20f;
    public static float critDamage = 1.5f;
    public static float baseDamageMultiplier = 1;
    
    public static float velocidade = 5.0f; // Velocidade na qual o inimigo vai se mover na direção do jogador.
    public Transform jogador; // Referência para a posição do jogador.

    void Start()
    {
        // Encontra o jogador no cenário utilizando a tag "Player".
        // Certifique-se de que seu jogador esteja marcado com essa tag.
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Verifica se o jogador foi encontrado.
        if(jogador)
        {
            // Calcula a direção do jogador a partir da posição atual do inimigo.
            Vector3 direcao = (jogador.position - transform.position).normalized;

            // Move o inimigo na direção do jogador.
            transform.position += direcao * velocidade * Time.deltaTime;

            // Opcional: Faz com que o inimigo sempre olhe na direção do jogador.
            // Quaternions são usados para representar rotações.
            transform.rotation = Quaternion.LookRotation(direcao);
        }
    }
    
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
