using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player player, string animBoolName, PlayStateMachine stateMachine) : base(player, animBoolName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0 , 0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if ((xInput != 0 || Mathf.Abs(rb.velocity.x) > 1e-4f) && !player.isBusy)
            stateMachine.ChangeState(player.moveState); 
    }
}
