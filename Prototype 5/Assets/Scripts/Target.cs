using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody _targetRb;

    private float _minSpeed = 12;
    private float _maxSpeed = 16;
    private float _torqueRange = 10;
    private float _xSpawnRange = 4;
    private float _ySpawnPos = -2;

    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange), _ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-_torqueRange, _torqueRange);
    }
}