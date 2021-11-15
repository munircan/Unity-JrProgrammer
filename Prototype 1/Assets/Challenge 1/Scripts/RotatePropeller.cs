using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
    private float speed = 5.0f;
    private void Update()
    {
        transform.Rotate(Vector3.forward * speed);
    }
}
