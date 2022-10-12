using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public MoveLeft moveLeftState;
    [HideInInspector]
    public MoveRight moveRightState;
    [HideInInspector]
    public MoveUp moveUpState;
    [HideInInspector]
    public MoveDown moveDownState;

    public Rigidbody cubeRigidbody;
    public Renderer cubeRenderer;
    public Transform cubeTransform;

    [HideInInspector]
    public float speed;
    


    private void Awake()
    {
        idleState = new Idle(this);
        moveLeftState = new MoveLeft(this);
        moveRightState = new MoveRight(this);
        moveDownState = new MoveDown(this);
        moveUpState = new MoveUp(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    private void OnGUI()
    {
        string content = speed.ToString();
        GUILayout.Label($"<color='black'><size=40>{"Speed is: " + content}</size></color>");
    }


}
