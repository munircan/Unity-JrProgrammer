using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private float spawnRange = 9.0f;

    private void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPos = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPos, 0, spawnPos);
        return randomPos;
    }
}