
public class BaseState 
{
    #region VARIABLES
    public string name;
    protected StateMachine stateMachine;
    #endregion

    #region CONSTRUCTOR
    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    #endregion

    #region STATE METHODS
    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
    #endregion


}
