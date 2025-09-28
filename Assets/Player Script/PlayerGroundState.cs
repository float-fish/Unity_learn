using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player player, string animBoolName, PlayStateMachine stateMachine) : base(player, animBoolName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!player.IsGroundDectected())
            stateMachine.ChangeState(player.airState);
        else if (Input.GetKeyDown(KeyCode.K) && player.IsGroundDectected())
            stateMachine.ChangeState(player.jumpState);
        if (Input.GetKeyDown(KeyCode.J))
        {
            stateMachine.ChangeState(player.primaryattackState);
        }
    }
}
