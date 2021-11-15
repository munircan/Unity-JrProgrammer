using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float forwardInput;
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        //Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * speed * forwardInput));
        //Rotate the vehicle sideways
        transform.Rotate(Vector3.up,Time.deltaTime * turnSpeed * horizontalInput);
    }
}
