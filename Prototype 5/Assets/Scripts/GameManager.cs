using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private GameObject targetsParent;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float _spawnRate = 1.0f;
    private int _score = 0;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        _score = 0;
        UpdateScore(0);
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index], targetsParent.transform, true);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score;
    }
}