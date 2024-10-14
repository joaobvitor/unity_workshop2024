using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private int jumpForce = 30;
    [SerializeField] private LayerMask groundLayer;

    private enum MovementState { Idle, Running};
    private Vector2 movement;
    private int facingDirection = 1;
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    private AudioSource audioSource;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate() {
        // If you want deceleration (speed and linear drag need to be adjusted)
        //if (movement.x != 0 || movement.y != 0) {
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        //}
        // Other movement method that adds acceleration (speed and linear drag need to be adjusted)
        //rb.AddForce(movement * speed);

        if (movement.x != 0 && movement.x != facingDirection) {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 0);
            facingDirection *= -1;
            transform.position = new Vector3(transform.position.x + transform.localScale.x * 1.5f, transform.position.y, 0);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        if (rb.velocity.x == 0) {
            anim.SetInteger("state", (int)MovementState.Idle);
        }
        else {
            anim.SetInteger("state", (int)MovementState.Running);
        }
    }

    private void OnMovement(InputValue value) {
        movement = value.Get<Vector2>();
    }

    private void OnJump() {
        if (IsGrounded()) {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            audioSource.Play();
        }
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
    }
}
