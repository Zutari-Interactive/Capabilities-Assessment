using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : BaseState
{
    private float _horizontalInput;
    private float _boundary;
    private float _cubeWidth;

    private MovementSM _sm;

    public MoveRight(MovementSM stateMachine) : base("Moving Right", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        _horizontalInput = 0f;
        _sm.cubeRenderer.material.SetColor("_Color", Color.blue);

        _cubeWidth = _sm.cubeTransform.transform.localScale.x;
        _boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0-Camera.main.transform.position.z)).x;


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

        if (_sm.cubeTransform.transform.position.x > _boundary + _cubeWidth/2)
        {
            _sm.cubeTransform.transform.position = new Vector3(_boundary * (-1) + _cubeWidth / 2, _sm.cubeTransform.transform.position.y, _sm.cubeTransform.transform.position.z);
        }

    }
}
