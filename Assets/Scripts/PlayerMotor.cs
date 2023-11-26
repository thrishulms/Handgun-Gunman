using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool crouching = false;
    private bool sprinting = false;

    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

        if (crouching)
        {
            characterController.height = Mathf.Lerp(characterController.height, 1, 10);
        }
        else
        {
            characterController.height = Mathf.Lerp(characterController.height, 2, 10);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            characterController.Move(playerVelocity * Time.deltaTime);
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        if (isGrounded)
        {
            playerVelocity.y = -2f;
        } else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        
        
        characterController.Move(playerVelocity * Time.deltaTime);

    }

    public void Crouch(bool isCrouchingInput)
    {
        crouching = isCrouchingInput;
    }

    public void Sprint(bool isSprintInput)
    {
        sprinting = isSprintInput;
        if(sprinting)
        {
            speed = 8f;
        } else
        {
            speed = 5f;
        }
    }
}
