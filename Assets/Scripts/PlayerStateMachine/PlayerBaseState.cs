
// Handles the superstates and the substates of the character 
public abstract class PlayerBaseState 
{

    
    private bool rootState = false;
    private PlayerStateMachine contxt;
    private PlayerStateFactory factory;
    private PlayerBaseState currentSubState;
    private PlayerBaseState currentSuperState;


    // inherited by deriveed classes so we have access to the context and factory from each of our concrete state 

    protected bool RootState { set { rootState = value; } }
    protected PlayerStateMachine Contxt { get { return contxt; } }
    protected PlayerStateFactory Factory { get { return factory; } }


    // to access memeber variables in another class 
    public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) {
        contxt = currentContext;
        factory = playerStateFactory;
    }



    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubStates();

    public void UpdateStates()
    {
        // update current substate

        UpdateState();
        if(currentSubState != null)
        {
            currentSubState.UpdateStates();
        }
    }

    protected void SwitchState(PlayerBaseState newState) {
        
        // exist current state 
        ExitState();

        // enter new state
        newState.EnterState();

        if (rootState)
        {
            // swtich currnet state
            contxt.CurrentState = newState;

        } else if (currentSuperState != null)
        {
            // set current sub state to the new super state
            currentSuperState.SetSubState(newState);
        } 
    }

    protected void SetSuperState(PlayerBaseState newSuperState) 
    {
        currentSuperState = newSuperState;
    }

    protected void SetSubState(PlayerBaseState newSubState) 
    {
        currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }

}
