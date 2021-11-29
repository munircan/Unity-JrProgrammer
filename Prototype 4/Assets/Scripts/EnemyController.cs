using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody enemyRb;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        var dir = (player.transform.position - transform.position).normalized;
        //enemyRb.velocity = dir * speed;
        enemyRb.AddForce(dir * speed);
        DestroyOutOfBounds();
    }


    private void DestroyOutOfBounds()
    {
        if (transform.position.y < -10) Destroy(gameObject);
    }
}