using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float scale;
    private void Update()
    {
        //Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * scale));
    }
}
