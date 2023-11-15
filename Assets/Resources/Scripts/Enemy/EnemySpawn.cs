using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    
    public Transform playerTransform;
    public GameObject[] enemyPrefabs;
    public int maxEnemies; 
    private static int currentEnemyCount;

    public float spawnInterval;

    // Limites dentro dos quais os inimigos podem ser spawnados, relativos à posição da câmera.
    public float minX = 0f;
    public float maxX = 10f;
    public float minZ = 0f;
    public float maxZ = 10f;

    void Update()
    {
        spawnInterval = DifficultyStatsController.Stats.entitiesDelaySpawnBase * Mathf.Pow(DifficultyStatsController.Stats.entitiesDelaySpawnDecrement, WorldStatsController.Stats.DayCounter -1);
        maxEnemies = (int)(DifficultyStatsController.Stats.maxEntitiesForNightBase * Mathf.Pow(
            DifficultyStatsController.Stats.DifficultyMaxEntitiesIncrementPerNight,
            WorldStatsController.Stats.DayCounter - 1));
    }

    void Start()
    {
        currentEnemyCount = 0;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            //Debug.Log("Está dia? " + WorldStatsController.Stats.IsDay);
            if (WorldStatsController.Stats.enemiesExisting++ < maxEnemies && !WorldStatsController.Stats.IsDay)
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
            0, // os inimigos serão spawnados na altura 0, ajuste conforme necessário
            Random.Range(cameraPosition.z + minZ, cameraPosition.z + maxZ)
        );

        // Certifique-se de que o inimigo está orientado corretamente, possivelmente em direção a um ponto de interesse.
        Quaternion spawnRotation = Quaternion.identity; // Isso pode ser modificado conforme necessário

        Instantiate(enemyPrefab, spawnPosition, spawnRotation);
        WorldStatsController.Stats.enemiesExisting++;
    }
    
}