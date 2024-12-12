using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    private PlayerState _currentState;

    public void SetState(PlayerState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }

    public void Update()
    {
        _currentState?.Update();
    }
}
