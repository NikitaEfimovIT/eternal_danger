using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IdleState : PlayerState
{
    public IdleState(PlayerScript player) : base(player) { }

    public override void Enter()
    {
        _player.animator.SetBool("isIdle", true);
    }

    public override void Exit()
    {
        _player.animator.SetBool("isIdle", false);
    }

    
    public override void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _player.characterController.isGrounded)
        {  
            Debug.Log("Jump");
            _player.ChangeState(new JumpingState(_player));
        }
        else if (_player.GetMoveDirection() != Vector3.zero)
        {
            _player.ChangeState(new MovingState(_player));
        }
    }
}
