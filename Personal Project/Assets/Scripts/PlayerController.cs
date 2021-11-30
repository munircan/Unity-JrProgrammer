using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody playerRb;
    private float boundZ = 10;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMovement();
        ConstrainPlayerPosition();
    }
    private void PlayerMovement()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerRb.velocity = speed * direction;
    }

    private void ConstrainPlayerPosition()
    {
        if (transform.position.z > boundZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundZ);
        }

        if (transform.position.z < -boundZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundZ);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Obstacle")) Debug.Log("Collided with Obstacle!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Supply")) Destroy(other.gameObject);
    }
}