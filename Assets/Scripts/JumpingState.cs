using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : PlayerState
{
    public JumpingState(PlayerScript player) : base(player) { }

    public override void Enter()
    {
        _player.animator.SetTrigger("jump");
        _player.Jump();
        
    }

    public override void Update()
    {
        _player.ApplyGravity(Physics.gravity.y, Time.deltaTime);
        if (_player.characterController.isGrounded)
        {
            // Transition to Idle or Moving state based on input
            if (_player.GetMoveDirection() == Vector3.zero)
            {
                _player.ChangeState(new IdleState(_player));
            }
            else
            {
                _player.ChangeState(new MovingState(_player));
            }
        }
    }
}
