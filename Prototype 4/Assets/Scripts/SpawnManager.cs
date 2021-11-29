using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerUpPrefab;
    private const float spawnRange = 9.0f;
    private int enemyCount;
    private int waveNumber = 1;


    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount.Equals(0))
        {
            SpawnEnemyWave(waveNumber);
            waveNumber++;
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (var i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        var spawnPos = Random.Range(-spawnRange, spawnRange);
        var randomPos = new Vector3(spawnPos, 0, spawnPos);
        return randomPos;
    }
}