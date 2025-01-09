using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    // ["PLAYER_PARAMETERS"]
    
    public float maxHealth = 100f;
    public float playerHealth;
    // ["PLAYER_MOVEMENT_PARAMETERS"]
    public float moveSpeed = 3f;
    public float jumpForce = 3f;
    
    // ["UTILS_PARAMETERS"]
    public Animator animator;
    public CharacterController characterController;

    private ControllerFacade _facade;
    private PlayerStateMachine _stateMachine;
    
    private InventoryFacade _inventory = new InventoryFacade();

    // public GameObject pauseCanvas;

    
    // ["FUNCTIONS"]
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _facade = new ControllerFacade(characterController, transform);
        _stateMachine = new PlayerStateMachine();
        _stateMachine.SetState(new IdleState(this));
        playerHealth = maxHealth;
    }

    private void Update()
    {
        HandleCursor();
        // HandlePause();
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
        if (!GameStateManager.Instance.onPause && !GameStateManager.Instance.onInventory)
        {
            Cursor.lockState = Input.GetKey(KeyCode.LeftAlt) ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

	// private void HandlePause()
	// {
 //        GameObject mainCanvas = GameObject.FindGameObjectWithTag("Canvas");
 //        if (Input.GetKeyDown(KeyCode.Escape))
 //        {
 //            Debug.Log("Escape");
 //            Debug.Log(pauseCanvas);
 //            Cursor.lockState = CursorLockMode.None;
 //            Time.timeScale = 0 ;
 //            mainCanvas.SetActive(false);
 //            pauseCanvas.SetActive(true);
 //        }
	// }

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
