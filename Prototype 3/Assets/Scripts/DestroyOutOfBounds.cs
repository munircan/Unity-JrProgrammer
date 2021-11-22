using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float bound;

    private void Update()
    {
        if (transform.position.x < bound)
        {
            Destroy(gameObject);
        }
    }
}
