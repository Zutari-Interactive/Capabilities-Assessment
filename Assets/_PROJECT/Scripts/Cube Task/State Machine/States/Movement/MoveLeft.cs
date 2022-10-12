using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : BaseState
{
    private MovementSM _sm;
    private float _horizontalInput; 

    public MoveLeft(MovementSM stateMachine) : base("Moving Left", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _sm.cubeRenderer.material.SetColor("_Color", Color.green);

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        {

            stateMachine.ChangeState(_sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        Vector2 velocity = _sm.cubeRigidbody.velocity;
        velocity.x = _horizontalInput * _sm.speed;
        _sm.cubeRigidbody.velocity = velocity;

    }
}
