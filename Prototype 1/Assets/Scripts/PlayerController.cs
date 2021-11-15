using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        //Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }
}
