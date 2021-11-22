using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private float jumpForce = 12.5f;
    private float gravityModifier = 2.0f;
    private bool isOnGround = true;
    public bool isGameOver = false;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) isOnGround = true;
        else if (other.gameObject.CompareTag("Obstacle")) isGameOver = true;
    }
}