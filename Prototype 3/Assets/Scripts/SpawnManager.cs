using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(30, 0, 0);
    private int index;
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;


    private void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    private void SpawnObstacles()
    {
        index = Random.Range(0, obstaclePrefab.Length);
        Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
    }
}