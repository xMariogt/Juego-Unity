using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float JumpForce;
    public float Speed;
    public Animator animator;
    public bool canMove = true;
    public AudioClip jumpSound;
    private AudioSource audioSource;
    private float movementX;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMove(InputValue movementValue)
    {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;

            if (movementX > 0) {
                transform.localScale = new Vector3(1, 1, 1);
            } else if (movementX < 0) {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (movementX == 0) {
                animator.SetBool("Run", false);
            } else
            animator.SetBool("Run", true);
        
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(movementX * Speed, rb.velocity.y);
    }

    private void Update() {

        
        
        if (CheckGround.isGrounded) {
            animator.SetBool("Jump", false);
        } else {
            animator.SetBool("Jump", true);
        }
    }


    private void OnJump()
    {
        if (CheckGround.isGrounded) {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }
        
    }

    

}
