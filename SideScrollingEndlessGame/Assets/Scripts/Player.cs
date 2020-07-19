using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float force;
    bool isTapped, isGrounded, startPlaying;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        GameManager.gameManager.OnGameplayStart += StartPlaying;
        GameManager.gameManager.OnGameplayEnd += StopPlaying;
    }

    void Update()
    {
        if (startPlaying)
        {
            isTapped = Input.GetMouseButtonDown(0);
        }
    }

    void FixedUpdate()
    {
        if (isTapped & isGrounded)
        {
            Jump();

            Animate("Jump");

            //tap sound
            AudioManager.audioManager.PlaySound(AudioManager.audioManager.clips.tap);
        }
    }

    void StartPlaying()
    {
        startPlaying = true;
        Animate("Run");
    }

    void StopPlaying()
    {
        startPlaying = false;
    }


    void Jump()
    {
        isGrounded = false;
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    void Animate(string trigger)
    {
        animator.SetTrigger(trigger);
    }

    void Lose()
    {
        Animate("Lose");

        //lose sound
        AudioManager.audioManager.PlaySound(AudioManager.audioManager.clips.lose);

        GameManager.gameManager.EndGameplay();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //player loses
            Lose();
        }
    }
}

