using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;

    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = characterController.isGrounded;
    }

    public void Jump()
    {
        
        if (isGrounded)
        {
            Debug.Log("Jump Clicked");
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
}
