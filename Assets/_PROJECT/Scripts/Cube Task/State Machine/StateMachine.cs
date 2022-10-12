using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    #region VARIABLES
    BaseState currentState;
    #endregion

    #region UNITY EVENTS
    void Start()
    {
        currentState = GetInitialState();

        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
        }
    }

    void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }
    #endregion

    #region STATE CHANGE
    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    

    #endregion
}
