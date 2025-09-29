using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimartAttackState : PlayerState
{
    private int ComboCounter = 0;

    private float lastTimeAttacked = 0f;
    private float comboWindow = 0.5f;

    private int AttackDir;
    public PlayerPrimartAttackState(Player player, string animBoolName, PlayStateMachine stateMachine) : base(player, animBoolName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (Time.time > lastTimeAttacked + comboWindow)
            ComboCounter = 0;
        player.anim.SetInteger("ComboCounter", ComboCounter);

        if (xInput == 0)
            AttackDir = player.FacingDir;
        else
            AttackDir = (int)xInput;

        player.SetVelocity(player.attackmovement[ComboCounter].x * AttackDir, player.attackmovement[ComboCounter].y);
        StateTimer = 0.1f;
        player.StartCoroutine("BusyFor", 0.15f);
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
