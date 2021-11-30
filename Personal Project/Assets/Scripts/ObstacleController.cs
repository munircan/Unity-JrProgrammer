using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody obstacleRb;
    private const float zBound = -15.0f;

    private void Awake()
    {
        obstacleRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        obstacleRb.AddForce(Vector3.forward * -speed);
        if (transform.position.z < zBound) Destroy(gameObject);
    }

}