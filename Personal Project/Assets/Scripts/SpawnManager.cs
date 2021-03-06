using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject supplyPrefab;
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject supplies;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 16.0f;
    private float zSupplySpawn = 5.0f;
    private float ySpawn = 0.51f;

    private float repeatRate = 2.0f;
    private float supplyRepeatRate = 5.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), repeatRate, repeatRate);
        InvokeRepeating(nameof(SpawnSupply),repeatRate,supplyRepeatRate);
    }
    

    private void SpawnEnemy()
    {
        var randomX = Random.Range(-xSpawnRange, xSpawnRange);
        var randomIndex = Random.Range(0, enemyPrefabs.Length);

        var spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        var enemy = Instantiate(enemyPrefabs[randomIndex], spawnPos, transform.rotation);
        enemy.transform.parent = enemies.transform;
    }

    private void SpawnSupply()
    {
        var randomX = Random.Range(-xSpawnRange, xSpawnRange);
        var randomZ = Random.Range(-zSupplySpawn, zSupplySpawn);
        var spawnPos = new Vector3(randomX, ySpawn, randomZ);

        var supply = Instantiate(supplyPrefab, spawnPos, transform.rotation);
        supply.transform.parent = supplies.transform;
    }
}