using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlayerScript : MonoBehaviour
// {
//     
//     private ControllerFacade _facade;
//
//     public float moveSpeed = 3f;
//     public float jumpForce = 30;
//     private float viewRotationSpeed = 300;
//     public CharacterController characterController;
//     private Vector3 playerVelocity;
//
//     void Start()
//     {
//         Cursor.lockState = CursorLockMode.Locked;
//     }
//     
//     void Update()
//     {
//         if (characterController.isGrounded && playerVelocity.y < 0)
//         {
//             playerVelocity.y = 0f;
//         }
//
//         Vector3 moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
//         moveDirection.y = 0;
//         moveDirection = moveDirection.normalized;
//         
//         Cursor.lockState = Input.GetKey(KeyCode.LeftAlt) ? CursorLockMode.None : CursorLockMode.Locked;
//
//        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
//         {
//             playerVelocity.y += Mathf.Sqrt(jumpForce * -2.0f * Physics.gravity.y);
//         }
//
//         playerVelocity.y += Physics.gravity.y * Time.deltaTime;
//         characterController.Move(playerVelocity * Time.deltaTime + moveDirection * (moveSpeed * Time.deltaTime));
//     }
//     
// }

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 3f;
    
    public Animator animator;
    public CharacterController characterController;

    private ControllerFacade _facade;
    private PlayerStateMachine _stateMachine;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _facade = new ControllerFacade(characterController, transform);
        _stateMachine = new PlayerStateMachine();
        _stateMachine.SetState(new IdleState(this));
    }

    private void Update()
    {
        HandleCursor();

        // Check for jump input and transition to JumpingState
        // Debug.Log(Input.GetKey(KeyCode.Space));

        UpdateAnimatorParameters();
        
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded)
        {
            ChangeState(new JumpingState(this));
        }
        else
        {
            _stateMachine.Update();
           
        }
        _facade.ApplyGravity(Physics.gravity.y, Time.deltaTime, GetMoveDirection(), moveSpeed);
    }
    public void ChangeState(PlayerState newState)
    {
        _stateMachine.SetState(newState);
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveDirection.y = 0;
        return moveDirection.normalized;
    }
    

    public void Move(Vector3 moveDirection)
    {
        _facade.Move(moveDirection, moveSpeed, Time.deltaTime);
    }

    public void Jump()
    {
        _facade.Jump(jumpForce, Physics.gravity.y);
    }

    private void HandleCursor()
    {
        Cursor.lockState = Input.GetKey(KeyCode.LeftAlt) ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void ApplyGravity(float gravity, float deltaTime)
    {
        _facade.ApplyGravity(gravity, deltaTime, GetMoveDirection(), moveSpeed);
    }
    
    private void UpdateAnimatorParameters()
    {
        // Set speed parameter based on movement
        Vector3 moveDirection = GetMoveDirection();
        animator.SetFloat("moveSpeed", moveDirection.magnitude);

        // Set grounded parameter
        animator.SetBool("isGrounded", characterController.isGrounded);

        // Set jumping parameter if vertical velocity is positive
        animator.SetBool("isJumping", characterController.velocity.y > 0);
    }
}
