using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, string animBoolName, PlayStateMachine stateMachine) : base(player, animBoolName, stateMachine)
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

        if(player.IsWallDectected())
            stateMachine.ChangeState(player.WallSlideState);

        if (player.IsGroundDectected()) 
            stateMachine.ChangeState(player.idleState);

        if (xInput != 0)
            player.SetVelocity(player.MoveSpeed * xInput * 0.8f, rb.velocity.y);
    }
}
