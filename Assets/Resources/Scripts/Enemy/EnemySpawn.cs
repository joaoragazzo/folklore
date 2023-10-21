using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject[] enemyPrefabs;
    public static int maxEnemies = 500;
    private static int currentEnemyCount;

    public float spawnInterval = 2f;

    // Limites dentro dos quais os inimigos podem ser spawnados, relativos à posição da câmera.
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;

    void Start()
    {
        currentEnemyCount = 0;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[enemyIndex];

        // Cria uma posição de spawn aleatória dentro dos limites definidos, usando a posição da câmera como referência.
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 spawnPosition = new Vector3(
            Random.Range(cameraPosition.x + minX, cameraPosition.x + maxX),
            playerTransform.position.y, // os inimigos serão spawnados na altura da câmera, ajuste conforme necessário
            Random.Range(cameraPosition.z + minZ, cameraPosition.z + maxZ)
        );

        // Certifique-se de que o inimigo está orientado corretamente, possivelmente em direção a um ponto de interesse.
        Quaternion spawnRotation = Quaternion.identity; // Isso pode ser modificado conforme necessário

        Instantiate(enemyPrefab, spawnPosition, spawnRotation);
        currentEnemyCount++;
    }

    public static void EnemyDefeated()
    {
        if (currentEnemyCount > 0)
            currentEnemyCount--;
    }
}