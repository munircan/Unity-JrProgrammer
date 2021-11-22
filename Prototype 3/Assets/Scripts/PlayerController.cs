using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    [SerializeField] private bool isOnGround;

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
            _playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter()
    {
        isOnGround = true;
    }
}