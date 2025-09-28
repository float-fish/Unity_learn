using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState {
    protected Player player;
    protected PlayStateMachine stateMachine;

    protected string animBoolName;
    protected float xInput;
    protected float yInput;
    protected float StateTimer;
    protected bool triggerCalled;

    protected Rigidbody2D rb;

    public PlayerState(Player player, string animBoolName, PlayStateMachine stateMachine){
        this.player = player;
        this.animBoolName = animBoolName;
        this.stateMachine = stateMachine;
        
    }

    public virtual void Update() {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
        StateTimer -= Time.deltaTime;
    }

    public virtual void Enter() {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        triggerCalled = false;
    }

    public virtual void Exit() {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
    
