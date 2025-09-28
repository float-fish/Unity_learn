using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimartAttackState : PlayerState
{
    private int ComboCounter = 0;

    private float lastTimeAttacked = 0f;
    private float comboWindow = 0.5f;
    public PlayerPrimartAttackState(Player player, string animBoolName, PlayStateMachine stateMachine) : base(player, animBoolName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (Time.time > lastTimeAttacked + comboWindow)
            ComboCounter = 0;
        player.anim.SetInteger("ComboCounter", ComboCounter);
        player.SetVelocity(player.attackmovement[ComboCounter].x * player.FacingDir, player.attackmovement[ComboCounter].y);
        StateTimer = 0.1f;
    }

    public override void Exit()
    {
        base.Exit();

        player.StartCoroutine("BusyFor", 0.15f);

        ComboCounter = (++ComboCounter) % 3;

        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if(StateTimer < 0)
            player.SetVelocity(0, 0);
        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }
}
