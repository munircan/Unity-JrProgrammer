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
    private float repeatRate = 4.0f;
    private PlayerController playerController;


    private void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnObstacles()
    {
        if (!playerController.isGameOver)
        {
            index = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
        }
    }
}