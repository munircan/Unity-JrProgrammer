using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        //var dir = new Vector3(0,0,Input.GetAxis("Vertical"));
        //playerRb.velocity = speed * dir;
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * (speed * verticalInput));
    }
}
