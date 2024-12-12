using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : PlayerState
{
    public MovingState(PlayerScript player) : base(player) { }

    public override void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _player.characterController.isGrounded)
        {
            _player.ChangeState(new JumpingState(_player));
        }
        else
        {
            Vector3 moveDirection = _player.GetMoveDirection();
            if (moveDirection == Vector3.zero)
            {
                _player.ChangeState(new IdleState(_player));
            }
            else
            {
                _player.Move(moveDirection);
            }
        }
    }
}
