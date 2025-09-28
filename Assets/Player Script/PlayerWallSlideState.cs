using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player player, string animBoolName, PlayStateMachine stateMachine) : base(player, animBoolName, stateMachine)
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

        if (Input.GetKeyDown(KeyCode.K))
        { 
            stateMachine.ChangeState(player.walljumpState);
            return;
        }

        if (yInput<0)
            player.SetVelocity(0, rb.velocity.y);
        else
            player.SetVelocity(0, rb.velocity.y * .7f);

        if (xInput * player.FacingDir < 0 || player.IsGroundDectected())
            stateMachine.ChangeState(player.idleState);
    }
}
