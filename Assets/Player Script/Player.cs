using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Moveinfo
    [Header("Move info")]
    public float MoveSpeed = 8f;
    public float JumpForce = 12f;

    [Header("Dash info")]
    [SerializeField] private float DashCoolDown = 0.4f;
    public float Dashcooltimer;
    public float DashSpeed = 20f;
    public float Dashduration = 0.25f;
    public float dashDir {  get; private set; }
    #endregion
    #region Collisioninfo
    [Header("Collision info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatisground;
    #endregion

    public int FacingDir { get; private set; } = 1;
    private bool FacingRight = true;   

    #region Compenents
    public Animator anim {  get; private set; }
    public Rigidbody2D rb { get; private set; }

    #endregion
    #region States
    public PlayStateMachine stateMachine { get; private set; }  

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }

    #endregion

    private void Awake()
    {
        stateMachine = new PlayStateMachine();

        idleState = new PlayerIdleState(this,"Idle",stateMachine);
        moveState = new PlayerMoveState(this,"Move",stateMachine);
        jumpState = new PlayerJumpState(this, "Jump", stateMachine);
        airState  = new PlayerAirState(this, "Jump", stateMachine);
        dashState = new PlayerDashState(this, "Dash", stateMachine);
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();
        CheckDashState();
    }

    private void CheckDashState()
    {   
        Dashcooltimer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.I) && Dashcooltimer < 0)
           {
            Dashcooltimer = DashCoolDown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
                dashDir = FacingDir;
            stateMachine.ChangeState(dashState); 
           }
    }

    public void SetVelocity(float velocity_x, float velocity_y)
    {
        rb.velocity = new Vector2 (velocity_x, velocity_y);
        FlipControl(velocity_x);
    }

    public bool IsGroundDectected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatisground);

    public void Flip()
    {
        FacingDir = FacingDir * -1;
        FacingRight = !FacingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipControl(float x)
    {
        if (x > 0 && !FacingRight) Flip();
        else if (x < 0 && FacingRight) Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y ));
    }
}
