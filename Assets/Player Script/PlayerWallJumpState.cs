using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player player, string animBoolName, PlayStateMachine stateMachine) : base(player, animBoolName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StateTimer = .4f;
        player.SetVelocity(-5 * player.FacingDir, player.JumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (StateTimer < 0)
            stateMachine.ChangeState(player.airState);
    }
}
    

