using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFacade
{
    private readonly CharacterController _characterController;
    private readonly Transform _transform;
    private Vector3 _velocity;

    public ControllerFacade(CharacterController characterController, Transform transform)
    {
        _characterController = characterController;
        _transform = transform;
    }

    public bool IsGrounded => _characterController.isGrounded;

    public void Move(Vector3 direction, float moveSpeed, float deltaTime)
    {
        _characterController.Move(direction * (moveSpeed * deltaTime));
    }

    public void ApplyGravity(float gravity, float deltaTime, Vector3 direction, float moveSpeed)
    {
        if (IsGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        _velocity.y += gravity * deltaTime;
        _characterController.Move(_velocity * deltaTime+direction*(moveSpeed*deltaTime));
    }

    public void Jump(float jumpForce, float gravity)
    {
        _velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
    }
}
