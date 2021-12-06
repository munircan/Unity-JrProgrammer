using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float horsePower;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float forwardInput;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera secondCamera;
    [SerializeField] private KeyCode switchKey = KeyCode.Space;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometer;
    [SerializeField] private TextMeshProUGUI rpmText;
    private float rpm;
    private Rigidbody playerRb;

    [SerializeField] private List<WheelCollider> wheels;
    private int wheelCount;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //Move the vehicle forward
            //transform.Translate(Vector3.forward * (Time.deltaTime * speed * forwardInput));
            playerRb.AddRelativeForce(Vector3.forward * (horsePower * forwardInput));
            //Rotate the vehicle sideways
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);


            speed = playerRb.velocity.magnitude * 3.6f;
            speedometer.text = "Speed: " + (int) speed + "kph";
            rpm = (speed % 30) * 40;
            rpmText.text = "RPM: " + (int) rpm;
        }


        if (!Input.GetKeyDown(switchKey)) return;
        mainCamera.enabled = !mainCamera.enabled;
        secondCamera.enabled = !secondCamera.enabled;
    }


    private bool IsOnGround()
    {
        wheelCount = 0;
        foreach (var wheel in wheels.Where(wheel => wheel.isGrounded))
        {
            wheelCount++;
        }

        return wheelCount.Equals(4);
    }
}