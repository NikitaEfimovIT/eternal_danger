using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 30;
    private float viewRotationSpeed = 300;
    public CharacterController characterController;
    private Vector3 playerVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        if (characterController.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveDirection.y = 0;
        moveDirection = moveDirection.normalized;
        
        Cursor.lockState = Input.GetKey(KeyCode.LeftAlt) ? CursorLockMode.None : CursorLockMode.Locked;

       if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * -2.0f * Physics.gravity.y);
        }

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime + moveDirection * (moveSpeed * Time.deltaTime));
    }
    
}
