using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject powerUpIndicator;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;
    private const float powerUpStrength = 15.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerUp = false;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        //var dir = new Vector3(0,0,Input.GetAxis("Vertical"));
        //playerRb.velocity = speed * dir;
        var verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * (speed * verticalInput));
        powerUpIndicator.transform.position = transform.position + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PowerUp")) return;
        hasPowerUp = true;
        Destroy(other.gameObject);
        StartCoroutine(PowerUpCountdownRoutine());
        powerUpIndicator.gameObject.SetActive(true);
    }

    private IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Enemy") || !hasPowerUp) return;
        var enemyRb = other.gameObject.GetComponent<Rigidbody>();
        var awayFromPlayer = other.transform.position - transform.position;
        enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        //Debug.Log("Collided with " + other.gameObject.name + "with power up set to " + hasPowerUp);
    }
}