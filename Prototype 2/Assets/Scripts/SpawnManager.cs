using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;
    private int index;
    private Vector3 spawnPos;
    private float delay = 2;
    private float repeatRate = 1.5f;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;


    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", delay, repeatRate);
    }


    private void SpawnRandomAnimal()
    {
        index = Random.Range(0, animalPrefabs.Length);
        spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[index], spawnPos, animalPrefabs[index].transform.rotation);
    }
}