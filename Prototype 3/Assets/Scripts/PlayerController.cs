using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private Animator playerAnim;
    private AudioSource playerAudioSource;
    [SerializeField] private ParticleSystem explosionParticleSystem;
    [SerializeField] private ParticleSystem dirtParticleSystem;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip jumpsSound;
    private float jumpForce = 12.5f;
    private float gravityModifier = 2.0f;
    private bool isOnGround = true;
    public bool isGameOver = false;
    

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticleSystem.Stop();
            playerAudioSource.PlayOneShot(jumpsSound);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticleSystem.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            explosionParticleSystem.Play();
            dirtParticleSystem.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudioSource.PlayOneShot(crashSound);
        }
    }
}