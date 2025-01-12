using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float maxHealth = 10f; // Устанавливаем 10 HP
    public float playerHealth;

    public float moveSpeed = 3f;
    public float jumpForce = 3f;

    public Animator animator;
    public CharacterController characterController;

    private ControllerFacade _facade;
    private PlayerStateMachine _stateMachine;
    private InventoryFacade _inventory = new InventoryFacade();

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

    public void ApplyGravity(float gravity, float deltaTime)
    {
        _facade.ApplyGravity(gravity, deltaTime, GetMoveDirection(), moveSpeed);
    }

    private void UpdateAnimatorParameters()
    {
        Vector3 moveDirection = GetMoveDirection();
        animator.SetFloat("moveSpeed", moveDirection.magnitude);
        animator.SetBool("isGrounded", characterController.isGrounded);
        animator.SetBool("isJumping", characterController.velocity.y > 0);
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log($"Player took damage! Current health: {playerHealth}");

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}
