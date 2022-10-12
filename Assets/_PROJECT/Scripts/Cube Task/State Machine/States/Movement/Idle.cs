using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    #region VARIABLES
    private float _horizontalInput;
    private float _verticalInput; 

    private MovementSM _sm;
    #endregion

    #region INITIALIZE
    public Idle(MovementSM stateMachine) :  base("Idle", stateMachine) 
    {
        _sm = (MovementSM)stateMachine;
    }
    #endregion

    #region STATE METHODS
    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _verticalInput = 0f;
        _sm.cubeRenderer.material.SetColor("_Color", Color.black);


    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        if (_horizontalInput < 0)
        {
         
            stateMachine.ChangeState(_sm.moveLeftState);
        }

        else if (_horizontalInput > 0)
        {

            stateMachine.ChangeState(_sm.moveRightState);
        }

        else if (_verticalInput < 0)
        {

            stateMachine.ChangeState(_sm.moveDownState);
        }
        else if (_verticalInput > 0)
        {

            stateMachine.ChangeState(_sm.moveUpState);
        }


    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        _sm.cubeRigidbody.velocity = Vector3.zero;

    }
    #endregion
}
