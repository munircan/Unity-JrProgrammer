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
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            index = Random.Range(0, animalPrefabs.Length);
            spawnPos = new Vector3(Random.Range(-10, 10), 0, 15);
            Instantiate(animalPrefabs[index], spawnPos, animalPrefabs[index].transform.rotation);
        }
        
    }
}
