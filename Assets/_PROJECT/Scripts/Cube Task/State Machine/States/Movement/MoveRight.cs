using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : BaseState
{
    #region VARIABLES
    private float _horizontalInput;
    private float _boundary;
    private float _cubeWidth;

    private MovementSM _sm;
    private Transform _cube;
    #endregion

    #region INITIALIZE STATE
    public MoveRight(MovementSM stateMachine) : base("Moving Right", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
        _cube = _sm.cubeTransform.transform;
    }
    #endregion

    #region STATE METHODS
    public override void Enter()
    {
        base.Enter();

        _horizontalInput = 0f;
        _sm.cubeRenderer.material.SetColor("_Color", Color.blue);

        _cubeWidth = _cube.localScale.x;
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

        if (_cube.position.x > _boundary + _cubeWidth/2)
        {
            _cube.position = new Vector3(_boundary * (-1) + _cubeWidth / 2, _cube.position.y, _cube.position.z);
        }

    }
    #endregion
}
