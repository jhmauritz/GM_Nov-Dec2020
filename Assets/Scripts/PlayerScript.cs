﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    public GameObject fighter;
    
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    
    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;
    private bool duck = false;
    private bool attack = false;
    private bool pickUp = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator.Play("Idle");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    public void OnDuck(InputAction.CallbackContext context)
    {
        duck = context.action.triggered;
    }

    public void OnPickUpItem(InputAction.CallbackContext context)
    {
        pickUp = context.action.triggered;
    }

    public void OnUseItem(InputAction.CallbackContext context)
    {
        attack = context.action.triggered;
    }
    
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, 0);
        controller.Move(move  * playerSpeed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (controller.velocity.magnitude > 0f)
        {
            animator.SetBool("Walk Forward", true);
        }
        else if (controller.velocity.magnitude <= 0f)
        {
            animator.SetBool("Walk Forward", false);
        }
    }
}
