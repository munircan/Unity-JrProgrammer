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
        Vector3 dir = (player.transform.position - transform.position).normalized;
        //enemyRb.velocity = dir * speed;
        enemyRb.AddForce(dir * speed);
    }
}