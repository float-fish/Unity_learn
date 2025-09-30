using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStateMachine
{
    public PlayerState currentState  { get; private set;}

    public void Initialize(PlayerState state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void ChangeState(PlayerState new_state)
    {   
        currentState.Exit();
        currentState = new_state;
        currentState.Enter();
    }
}
