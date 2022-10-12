using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : BaseState
{
    private float _verticalInput;

    private MovementSM _sm;

    public MoveUp(MovementSM stateMachine) : base("Moving Up", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _verticalInput = 0f;
        _sm.cubeRenderer.material.SetColor("_Color", Color.red);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(_verticalInput) < Mathf.Epsilon)
        {

            stateMachine.ChangeState(_sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        Vector2 velocity = _sm.cubeRigidbody.velocity;
        velocity.y = _verticalInput * _sm.speed;
        _sm.cubeRigidbody.velocity = velocity;

    }
}
