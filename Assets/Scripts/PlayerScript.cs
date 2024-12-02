using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    
    public Rigidbody player;
    
    public Camera cam;
    public float jumpForce = 30;
    
    public float gravity = Physics.gravity.y;
    private bool isGrounded = true;

    private float viewRotationSpeed = 300;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Vector3 moveDirection = Camera.main.transform.TransformDirection(inputDirection);
        bool altPressed = Input.GetKey(KeyCode.LeftAlt);
        float playerJump = Input.GetAxis("Jump");

        if (altPressed)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (playerJump != 0 && isGrounded)
        {
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // if (playerJump == 0 && player.velocity.y < 0)
        // {
        //     player.AddForce(Vector3.down*gravity, ForceMode.Impulse);
        // }

        if (playerJump == 0 && player.velocity.y == 0)
        {
            isGrounded = true;
        }

        // player.Move(moveDirection * moveSpeed * Time.deltaTime);
        player.transform.Translate(new Vector3(moveDirection.x * moveSpeed * Time.deltaTime,
            0, moveDirection.z * moveSpeed * Time.deltaTime));
    }
    
}
