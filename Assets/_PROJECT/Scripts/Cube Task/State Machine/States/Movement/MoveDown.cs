using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : BaseState
{
    #region VARIABLES
    private float _verticalInput;

    private float _boundary;
    private float _cubeHeight;

    private MovementSM _sm;
    private Transform _cube;
    #endregion

    #region INITIALIZE
    public MoveDown(MovementSM stateMachine) : base("Moving Down", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
        _cube = _sm.cubeTransform.transform;
    }
    #endregion

    #region STATE METHODS
    public override void Enter()
    {
        base.Enter();
        _verticalInput = 0f;
        _sm.cubeRenderer.material.SetColor("_Color", Color.yellow);

        _cubeHeight = _cube.localScale.y;
        _boundary = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0 - Camera.main.transform.position.z)).y;
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

        if (_cube.position.y < _boundary - _cubeHeight / 2)
        {
            _cube.position = new Vector3(_cube.position.x, _boundary * (-1) - _cubeHeight / 2 , _cube.position.z);
        }

    }
    #endregion
}

