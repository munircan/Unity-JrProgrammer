using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerController playerController;
    private float bound = -10;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!playerController.isGameOver) transform.Translate(Vector3.left * (Time.deltaTime * speed));
        if (transform.position.x < bound && gameObject.CompareTag("Obstacle")) Destroy(gameObject);
    }
}