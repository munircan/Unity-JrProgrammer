using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    private float _spawnRate = 1.0f;


    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}