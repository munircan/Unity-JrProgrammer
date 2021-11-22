using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPos;
    private float _sizeX;

    private void Start()
    {
        _startPos = transform.position;
        _sizeX = GetComponent<BoxCollider>().size.x;
    }

    private void Update()
    {
        if (transform.position.x < _startPos.x - _sizeX / 2) transform.position = _startPos;
    }
}